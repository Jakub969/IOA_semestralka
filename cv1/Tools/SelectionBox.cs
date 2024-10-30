namespace cv1.Tools
{
    public static class SelectionBox
    {
        private static readonly SolidBrush fillBrush;
        public static Point StartingMousePosition; 
        private static Rectangle trackerRectangleFromPreviousStep;
        public static bool IsActive { get; set; }
        public static Rectangle TrackedRectangle { get { return trackerRectangleFromPreviousStep; } }

        static SelectionBox()
        {
            fillBrush = new SolidBrush(Color.FromArgb(120, 0, 116, 231));
            IsActive = false;
        }

        private static Rectangle GetRect(Point endPoint)
        {
            Rectangle outRect = new (StartingMousePosition.X, 
                                     StartingMousePosition.Y, 
                                     endPoint.X - StartingMousePosition.X, 
                                     endPoint.Y - StartingMousePosition.Y);

            if (outRect.Width < 0)
                outRect = new(endPoint.X, outRect.Y, -outRect.Width, outRect.Height);

            if (outRect.Height < 0)
                outRect = new(outRect.X, endPoint.Y, outRect.Width, -outRect.Height);

            return outRect;
        }

        public static void Draw(Graphics g)
        {
            if (!IsActive)
                return;

            g.FillRectangle(fillBrush, trackerRectangleFromPreviousStep);
        }

        public static Region Track(Point nowPoint)
        {
            Rectangle nowRectangle = GetRect(nowPoint);

            Region a = new (trackerRectangleFromPreviousStep);
            a.Xor(nowRectangle);
            trackerRectangleFromPreviousStep = nowRectangle;

            return a;
        }

    }
}
