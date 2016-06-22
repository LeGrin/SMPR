using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace Modules.VotingMethods
{
    class RectangleInfo
    {
        private RectangleF rect;
        private Element info;

        public RectangleF Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        internal Element Info
        {
            get { return info; }
            set { info = value; }
        }

        public RectangleInfo(Element info)
        {
            this.info = info;
        }

        public RectangleInfo(RectangleF rect)
        {
            this.rect = rect;
        }

        public RectangleInfo(RectangleF rect, Element info)
        {
            this.rect = rect;
            this.info = info;
        }
        
    }

    class SequenceRenderer
    {
        Graphics gSurface;
        Bitmap bmp;

        List<RectangleInfo> rectSequence;
        RectangleInfo selected;
        Color rectColor, selColor, gridColor = Color.FromKnownColor(KnownColor.InactiveBorder);

        int sizeX, sizeY;
        float spaceX, spaceY;
        float Ox, Oy;

        public Color SelColor
        {
            get { return selColor; }
            set { selColor = value; }
        }

        public Color RectColor
        {
            get { return rectColor; }
            set { rectColor = value; }
        }

        public Bitmap Bmp
        {
            get { return bmp; }
            set { bmp = value; }
        }

        public SequenceRenderer()
        {
        }

        public SequenceRenderer(int width, int height, Element[] sequence)
        {
            rectSequence = new List<RectangleInfo>();

            for (int i = 0; i < sequence.Length; i++)
                rectSequence.Add(new RectangleInfo(sequence[i]));

            Resize(width, height);
        }

        public SequenceRenderer(int width, int height, Element[] sequence, Color rectColor, Color selColor)
            : this(width, height, sequence)
        {
            this.rectColor = rectColor;
            this.selColor = selColor;
        }

        public void SelectRectangle(int pointX, int pointY)
        {
            bool selectionChanged = false, isSelected = false;
            RectangleInfo oldSelected = selected;

            for (int i = 0; i < rectSequence.Count; i++)
                if (rectSequence[i].Rect.Contains(new Point(pointX, pointY)) == true)
                {
                    selected = rectSequence[i];
                    isSelected = true;
                    if (selected != oldSelected)
                        selectionChanged = true;
                    break;
                }

            if (isSelected == false)
            {
                selected = null;
                selectionChanged = true;
            }

            if (selectionChanged == true)
            {
                if (oldSelected != null)
                    DrawRectangleInfo(oldSelected, Color.White, Color.White); //clearing old rectinfo

                DrawGrid(); // repainting grid

                DrawSequence(); // repainting all rects

                if (selected != null)
                    DrawRectangleInfo(selected, Color.Black, selColor); //painting new rectinfo
            }
        }

        public void Resize(int width, int height)
        {
            sizeX = width;
            sizeY = height;

            Ox = sizeX * 0.01f;
            Oy = sizeY * 0.01f;

            spaceX = (sizeX - 2 * Ox) / (rectSequence.Count + 2);
            spaceY = (sizeY - 2 * Oy) / (rectSequence.Count + 2);

            for (int i = 0; i < rectSequence.Count; i++)
            {
                float x = Ox + (i + 1) * spaceX,
                    y = Oy + (Convert.ToInt32(rectSequence[i].Info.Tag) + 1) * spaceY,
                    rectWidth = spaceX,
                    rectHeight = (rectSequence.Count - Convert.ToInt32(rectSequence[i].Info.Tag) + 1) * spaceY;
                rectSequence[i].Rect = new RectangleF(x, y, rectWidth, rectHeight);                
            }

            bmp = new Bitmap(sizeX, sizeY);

            gSurface = Graphics.FromImage(bmp);
            gSurface.Clear(Color.White);
        }

        public void DrawAxes()
        {
            Pen pen = new Pen(Color.Black, 2);
            pen.EndCap = LineCap.SquareAnchor;
            gSurface.DrawLine(pen, new PointF(Ox, sizeY - Oy), new PointF(sizeX - Ox, sizeY - Oy));
            gSurface.DrawLine(pen, new PointF(sizeX - Ox, Oy), new PointF(sizeX - Ox, sizeY - Oy));

            gSurface.DrawLine(pen, new PointF(Ox, Oy), new PointF(Ox, sizeY - Oy)); //vertical axe
            gSurface.DrawLine(pen, new PointF(Ox, Oy), new PointF(sizeX - Ox, Oy)); //vertical axe     
        }

        public void DrawGrid()
        {
            Pen pen = new Pen(gridColor, 1);
            pen.DashStyle = DashStyle.Dash;

            for (int i = 0; i < rectSequence.Count + 1; i++)
                gSurface.DrawLine(pen, new PointF(spaceX * (i + 1) + Ox, Oy), new PointF(spaceX * (i + 1) + Ox, sizeY - Oy)); // vertical lines

            for (int i = 0; i < rectSequence.Count + 1; i++)
                gSurface.DrawLine(pen, new PointF(Ox, spaceY * (i + 1) + Oy), new PointF(sizeX - Ox, spaceY * (i + 1) + Oy)); // horizontal lines
        }

        public void DrawRectangleInfo(RectangleInfo RectInfo, Color lineColor, Color fillColor)
        {
            Font f = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(lineColor);
            Pen pen = new Pen(lineColor, 1);

            SizeF stringSize = gSurface.MeasureString(RectInfo.Info.Text, f);
            PointF point = new PointF(RectInfo.Rect.Left + (RectInfo.Rect.Width - stringSize.Width) / 2, RectInfo.Rect.Top - 30);
            RectangleF textRect = new RectangleF(point.X, point.Y, stringSize.Width+2, stringSize.Height);

            gSurface.FillRectangle(new SolidBrush(fillColor), textRect);
            gSurface.DrawRectangle(pen, textRect.X, textRect.Y, textRect.Width, textRect.Height);
            gSurface.DrawLine(pen, new PointF(RectInfo.Rect.Left + RectInfo.Rect.Width / 2, RectInfo.Rect.Top), new PointF(RectInfo.Rect.Left + RectInfo.Rect.Width / 2, textRect.Bottom));

            gSurface.DrawString(RectInfo.Info.Text, f, brush, point);
        }

        public void DrawRectangle(RectangleF rect, Color fillColor)
        {
            SolidBrush brush = new SolidBrush(fillColor);
            gSurface.FillRectangle(brush, rect);
            gSurface.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void DrawRectPlace(RectangleInfo RectInfo, Color textColor)
        {
            Font f = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(textColor);
            Pen pen = new Pen(textColor, 1);

            SizeF stringSize = gSurface.MeasureString(RectInfo.Info.Tag.ToString(), f);
            PointF point = new PointF(RectInfo.Rect.Left + (RectInfo.Rect.Width - stringSize.Width) / 2, RectInfo.Rect.Top + 10);
            
            gSurface.DrawString(RectInfo.Info.Tag.ToString(), f, brush, point);
        }

        public void DrawSequence()
        {
            Color fillColor;
            for (int i = 0; i < rectSequence.Count; i++)
            {
                if (rectSequence[i] == selected)
                    fillColor = selColor;
                else fillColor = rectColor;

                DrawRectangle(rectSequence[i].Rect, fillColor);
                DrawRectPlace(rectSequence[i], Color.Black);
            }
        }

        public void Render()
        {
            DrawAxes();
            DrawGrid();
            DrawSequence();
        }

        public void RenderCleanGraphic()
        {
            DrawAxes();
            DrawGrid();
        }
    }
}
