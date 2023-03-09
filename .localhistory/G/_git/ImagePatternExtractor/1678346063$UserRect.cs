/*
 * from https://www.codeproject.com/Articles/30434/A-Resizable-Graphical-Rectangle
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class Control_Ext
{
    public static Point PointToScreen(this Control thisCtrl, int x, int y)
    {
        return thisCtrl.PointToScreen(new Point(x, y));
    }
}

namespace UserRectDemo
{
    public class UserRect 
    {        
        private PictureBox mPictureBox;
        private Rectangle rectDraw;
        private bool mIsClick=false;
        private bool mMove=false;        
        private int oldX;
        private int oldY;
        private int sizeNodeRect= 3;
        private PosSizableRect nodeSelected = PosSizableRect.None;

        public Rectangle rect;
        public bool allowDeformingDuringMovement=false ;
        public bool DrawResizeHandles = false;
        public int xSnapSize = 1;
        public int ySnapSize = 1;
        public int SnapSize { set { xSnapSize = value; ySnapSize = value; } }
        public Action<Rectangle> SizeChanged;

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

        public UserRect(Rectangle r, PictureBox p)
        {
            rect = r;
            SnapRectangle();
            mIsClick = false;
            SetPictureBox(p);
        }

        public void Draw(Graphics g)
        {                     
            g.DrawRectangle(new Pen(Color.Red),rectDraw);
            
            if (DrawResizeHandles)
                foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
                    g.DrawRectangle(new Pen(Color.Red),GetRect(pos));
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
            ChangeCursor(e.Location);
            if (mIsClick == false)
            {
                return;
            }

            int x = e.X, y = e.Y;
            if (x < 0) { x = 0; Cursor.Position = mPictureBox.PointToScreen(x, y); }
            if (y < 0) { y = 0; Cursor.Position = mPictureBox.PointToScreen(x, y); }
            if (x > mPictureBox.Width) { x = mPictureBox.Width - 1; Cursor.Position = mPictureBox.PointToScreen(x, y); }
            if (y > mPictureBox.Height) { y = mPictureBox.Height - 1; Cursor.Position = mPictureBox.PointToScreen(x, y); }
            int dx = x - oldX;
            int dy = y - oldY;
            oldX = x;
            oldY = y;


            

            Rectangle backupRect = rect;
            bool sizeChanged = true;
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
                    sizeChanged = false;
                    if (mMove)
                    {
                            rect.X = rect.X + dx;
                            rect.Y = rect.Y + dy;
                    }
                    break;
            }

            if (rect.Width < Math.Max(5,xSnapSize) || rect.Height < Math.Max(5,ySnapSize))
            {
                rect = backupRect;
            }

            //TestIfRectInsideArea();

            if (SizeChanged != null)
            {
                SizeChanged(new Rectangle(
                    (rect.X / xSnapSize) * xSnapSize,
                    (rect.Y / ySnapSize) * ySnapSize,
                    (rect.Width / xSnapSize) * xSnapSize,
                    (rect.Height / ySnapSize) * ySnapSize));
            }
            SnapRectangle();

            mPictureBox.Invalidate();
        }

        private void SnapRectangle()
        {
            rectDraw.X = (rect.X / xSnapSize) * xSnapSize;
            rectDraw.Y = (rect.Y / ySnapSize) * ySnapSize;
            rectDraw.Width = (rect.Width / xSnapSize) * xSnapSize;
            rectDraw.Height = (rect.Height / ySnapSize) * ySnapSize;
        }

        private void TestIfRectInsideArea()
        {
            // Test if rectangle still inside the area.
            if (rect.X < 0) rect.X = 0;
            if (rect.Y < 0) rect.Y = 0;
            if (rect.Width <= 0) rect.Width = xSnapSize;
            if (rect.Height <= 0) rect.Height = ySnapSize;

            if (rect.Right > mPictureBox.Width)
            {
                rect.Width = mPictureBox.Width - rect.X;// - 1; // -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
            if (rect.Bottom > mPictureBox.Height)
            {
                rect.Height = mPictureBox.Height - rect.Y;// - 1;// -1 to be still show 
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
        private Rectangle CreateRectSizableNode(int x, int y, int width, int height)
        {
            return new Rectangle(x - width / 2, y - height / 2, width, height);
        }

        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(rectDraw.X, rectDraw.Y);
                 
                case PosSizableRect.LeftMiddle:
                    return CreateRectSizableNode(rectDraw.X, rectDraw.Y + rectDraw.Height / 2, sizeNodeRect, rectDraw.Height - sizeNodeRect*2);                    

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(rectDraw.X, rectDraw.Y + rectDraw.Height);                                   

                case PosSizableRect.BottomMiddle:
                    return CreateRectSizableNode(rectDraw.X  + rectDraw.Width / 2, rectDraw.Y + rectDraw.Height, rectDraw.Width - sizeNodeRect*2, sizeNodeRect);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(rectDraw.X + rectDraw.Width, rectDraw.Y );

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(rectDraw.X  + rectDraw.Width, rectDraw.Y  + rectDraw.Height);

                case PosSizableRect.RightMiddle:
                    return CreateRectSizableNode(rectDraw.X  + rectDraw.Width, rectDraw.Y  + rectDraw.Height / 2, sizeNodeRect, rectDraw.Height - sizeNodeRect*2);

                case PosSizableRect.UpMiddle:
                    return CreateRectSizableNode(rectDraw.X + rectDraw.Width/2, rectDraw.Y, rectDraw.Width - sizeNodeRect*2, sizeNodeRect);
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
