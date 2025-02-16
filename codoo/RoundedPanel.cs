using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        int radius = 40; // حجم الزوايا المدورة
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, radius, radius, 180, 90); // الزاوية العلوية اليسرى
        path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // الزاوية العلوية اليمنى
        path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // الزاوية السفلية اليمنى
        path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // الزاوية السفلية اليسرى
        path.CloseAllFigures();

        this.Region = new Region(path); // تحديد الشكل
    }
}
