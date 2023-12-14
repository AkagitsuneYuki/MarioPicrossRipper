using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MarioPicrossRipper
{
	/// <summary>
	/// Inherits from PictureBox; adds Interpolation Mode Setting
	/// </summary>
	public class PixelPerfectPictureBox : PictureBox
	{
		/// <summary>
		/// The Interpolation Mode to use when drawing the image.
		/// This is set to Nearest Neighbor by default to maintain the pixel-perfect look of the original low-resolution image.
		/// </summary>
		public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.NearestNeighbor;

		/// <summary>
		/// The Pixel Offset Mode to use when drawing the image.
		/// This is set to Half to prevent pixels getting cut off.
		/// </summary>
		public PixelOffsetMode OffsetMode { get; set; } = PixelOffsetMode.Half;

		protected override void OnPaint(PaintEventArgs paintEventArgs)
		{
			paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
			paintEventArgs.Graphics.PixelOffsetMode = OffsetMode;
			base.OnPaint(paintEventArgs);
		}
	}
}