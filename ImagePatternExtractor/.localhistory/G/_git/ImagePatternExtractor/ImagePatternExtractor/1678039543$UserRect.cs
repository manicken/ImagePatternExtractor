/*
 * from https://www.codeproject.com/Articles/30434/A-Resizable-Graphical-Rectangle
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UserRectDemo
{
    public class UserRect 
    {        
        private PictureBox mPictureBox;
        public Rectangle rect;
        public bool allowDeformingDuringMovement=false ;
        public int xSnapSize = 1;
        public int ySnapSize = 1;
        private bool mIsClick=false;
        private bool mMove=false;        
        private int oldX;
        private int oldY;
        private int sizeNodeRect= 5;
        private Bitmap mBmp=null;
        private PosSizableRect nodeSelected = PosSizableRect.None;
        private int angle = 30;

        public delegate void SizeChanged(Rectangle rect);
        public SizeChanged sizeChanged;

        private enum PosSizableRect
        {            
            UpMiddle,
            LeftMiddle,
            LeftBottom,
            LeftUp,
            RightUp,
            RightMiddle,
            RightBottom,
            BottomMiddle,
            None

        };

        public UserRect(Rectangle r)
        {
            rect = r;
            mIsClick = false;
        }

        public void Draw(Graphics g)
        {                     
            g.DrawRectangle(new Pen(Color.Red),rect);
            
            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
              g.DrawRectangle(new Pen(Color.Red),GetRect(pos));
            }                       
        }

        public void SetBitmapFile(string filename)
        {
            this.mBmp = new Bitmap(filename);
        }

        public void SetBitmap(Bitmap bmp)
        {
            this.mBmp = bmp;
        }

        public void SetPictureBox(PictureBox p)
        {
            this.mPictureBox = p;
            mPictureBox.MouseDown +=new MouseEventHandler(mPictureBox_MouseDown);
            mPictureBox.MouseUp += new MouseEventHandler(mPictureBox_MouseUp);
            mPictureBox.MouseMove += new MouseEventHandler(mPictureBox_MouseMove);            
            mPictureBox.Paint += new PaintEventHandler(mPictureBox_Paint);
        }

        private void mPictureBox_Paint(object sender, PaintEventArgs e)
        {
            
            try
            {
                Draw(e.Graphics);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
            
        }

        private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mIsClick = true;

            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);
                
            if (rect.Contains(new Point(e.X,e.Y)))
            {
                mMove = true;                            
            }
            oldX = e.X;
            oldY = e.Y;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mIsClick = false;
            mMove = false;            
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X, y = e.Y;
            int dx = x - oldX;
            int dy = y - oldY;
            oldX = x;
            oldY = y;


            ChangeCursor(e.Location);
            if (mIsClick == false)
            {
                return;
            }

            Rectangle backupRect = rect;

            switch (nodeSelected)
            {
                case PosSizableRect.LeftUp:
                    rect.X += dx;
                    rect.Width -= dx;                    
                    rect.Y += dy;
                    rect.Height -= dy;
                    break;
                case PosSizableRect.LeftMiddle:
                    rect.X += dx;
                    rect.Width -= dx;
                    break;
                case PosSizableRect.LeftBottom:
                    rect.Width -= dx;
                    rect.X += dx;
                    rect.Height += dy;
                    break;
                case PosSizableRect.BottomMiddle:
                    rect.Height += dy;
                    break;
                case PosSizableRect.RightUp:
                    rect.Width += dx;
                    rect.Y += dy;
                    rect.Height -= dy;
                    break;
                case PosSizableRect.RightBottom:
                    rect.Width +=  dx;
                    rect.Height += dy;
                    break;
                case PosSizableRect.RightMiddle:
                    rect.Width += dx;
                    break;

                case PosSizableRect.UpMiddle:
                    rect.Y += dy;
                    rect.Height -= dy;
                    break;

                default:
                    if (mMove)
                    {
                            rect.X = rect.X + dx;
                            rect.Y = rect.Y + dy;
                    }
                    break;
            }
            

            

            if (rect.Width < 5 || rect.Height < 5)
            {
                rect = backupRect;
            }

            TestIfRectInsideArea();

            if (SizeChanged != null)
            {

            }
            rect.X = (rect.X / xSnapSize) * xSnapSize;
           // rect.Y = (rect.Y / ySnapSize) * ySnapSize;
            //rect.Width = (rect.Width / xSnapSize) * xSnapSize;
            //rect.Height = (rect.Height / ySnapSize) * ySnapSize;

            mPictureBox.Invalidate();
        }

        

        private void TestIfRectInsideArea()
        {
            // Test if rectangle still inside the area.
            if (rect.X < 0) rect.X = 0;
            if (rect.Y < 0) rect.Y = 0;
            if (rect.Width <= 0) rect.Width = 1;
            if (rect.Height <= 0) rect.Height = 1;

            if (rect.X + rect.Width > mPictureBox.Width)
            {
                rect.Width = mPictureBox.Width - rect.X - 1; // -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
            if (rect.Y + rect.Height > mPictureBox.Height)
            {
                rect.Height = mPictureBox.Height - rect.Y - 1;// -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
        }        

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);   
        }

        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(rect.X, rect.Y);
                 
                case PosSizableRect.LeftMiddle:
                    return CreateRectSizableNode(rect.X, rect.Y + +rect.Height / 2);                    

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(rect.X, rect.Y +rect.Height);                                   

                case PosSizableRect.BottomMiddle:
                    return CreateRectSizableNode(rect.X  + rect.Width / 2,rect.Y + rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(rect.X + rect.Width,rect.Y );

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(rect.X  + rect.Width,rect.Y  + rect.Height);

                case PosSizableRect.RightMiddle:
                    return CreateRectSizableNode(rect.X  + rect.Width, rect.Y  + rect.Height / 2);

                case PosSizableRect.UpMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width/2, rect.Y);
                default :
                    return new Rectangle();
            }
        }

        private PosSizableRect GetNodeSelectable(Point p)
        {
           foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;                    
                }
            }
            return PosSizableRect.None;
        }

        private void ChangeCursor(Point p)
        {
            mPictureBox.Cursor = GetCursor(GetNodeSelectable(p));
        }

        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return Cursors.SizeNWSE;               

                case PosSizableRect.LeftMiddle:
                    return Cursors.SizeWE;

                case PosSizableRect.LeftBottom:
                    return Cursors.SizeNESW;

                case PosSizableRect.BottomMiddle:
                    return Cursors.SizeNS;

                case PosSizableRect.RightUp:
                    return Cursors.SizeNESW;

                case PosSizableRect.RightBottom:
                    return Cursors.SizeNWSE;

                case PosSizableRect.RightMiddle:
                    return Cursors.SizeWE;

                case PosSizableRect.UpMiddle:
                    return Cursors.SizeNS;
                default:
                    return Cursors.Default;
            }
        }

    }
}
