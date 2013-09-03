using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BatchJPEGCompressor
{
    public partial class BatchJPEGCompressor : Form
    {
        #region Public Methods
        public BatchJPEGCompressor()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void InitializeComponent()
        {
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.ResolutionTextBox = new System.Windows.Forms.TextBox();
            this.QualityTextBox = new System.Windows.Forms.TextBox();
            this.InputBrowseButton = new System.Windows.Forms.Button();
            this.CompressButton = new System.Windows.Forms.Button();
            this.OutputBrowseButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.ResolutionLabel = new System.Windows.Forms.Label();
            this.QualityLabel = new System.Windows.Forms.Label();
            this.InputBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OutputBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point( 67, 6 );
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ReadOnly = true;
            this.InputTextBox.Size = new System.Drawing.Size( 200, 20 );
            this.InputTextBox.TabIndex = 0;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point( 67, 32 );
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size( 200, 20 );
            this.OutputTextBox.TabIndex = 1;
            // 
            // ResolutionTextBox
            // 
            this.ResolutionTextBox.Location = new System.Drawing.Point( 67, 58 );
            this.ResolutionTextBox.MaxLength = 3;
            this.ResolutionTextBox.Name = "ResolutionTextBox";
            this.ResolutionTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.ResolutionTextBox.TabIndex = 2;
            // 
            // QualityTextBox
            // 
            this.QualityTextBox.Location = new System.Drawing.Point( 197, 58 );
            this.QualityTextBox.MaxLength = 3;
            this.QualityTextBox.Name = "QualityTextBox";
            this.QualityTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.QualityTextBox.TabIndex = 3;
            // 
            // InputBrowseButton
            // 
            this.InputBrowseButton.Location = new System.Drawing.Point( 273, 6 );
            this.InputBrowseButton.Name = "InputBrowseButton";
            this.InputBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.InputBrowseButton.TabIndex = 4;
            this.InputBrowseButton.Text = "Browse";
            this.InputBrowseButton.UseVisualStyleBackColor = true;
            this.InputBrowseButton.Click += new System.EventHandler( this.InputBrowseButton_Click );
            // 
            // CompressButton
            // 
            this.CompressButton.Location = new System.Drawing.Point( 12, 97 );
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size( 336, 23 );
            this.CompressButton.TabIndex = 5;
            this.CompressButton.Text = "Compress";
            this.CompressButton.UseVisualStyleBackColor = true;
            this.CompressButton.Click += new System.EventHandler( this.CompressButton_Click );
            // 
            // OutputBrowseButton
            // 
            this.OutputBrowseButton.Location = new System.Drawing.Point( 273, 30 );
            this.OutputBrowseButton.Name = "OutputBrowseButton";
            this.OutputBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.OutputBrowseButton.TabIndex = 7;
            this.OutputBrowseButton.Text = "Browse";
            this.OutputBrowseButton.UseVisualStyleBackColor = true;
            this.OutputBrowseButton.Click += new System.EventHandler( this.OutputBrowseButton_Click );
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point( 27, 9 );
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size( 34, 13 );
            this.InputLabel.TabIndex = 8;
            this.InputLabel.Text = "Input:";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point( 19, 35 );
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size( 42, 13 );
            this.OutputLabel.TabIndex = 9;
            this.OutputLabel.Text = "Output:";
            // 
            // ResolutionLabel
            // 
            this.ResolutionLabel.AutoSize = true;
            this.ResolutionLabel.Location = new System.Drawing.Point( 1, 61 );
            this.ResolutionLabel.Name = "ResolutionLabel";
            this.ResolutionLabel.Size = new System.Drawing.Size( 60, 13 );
            this.ResolutionLabel.TabIndex = 11;
            this.ResolutionLabel.Text = "Resolution:";
            // 
            // QualityLabel
            // 
            this.QualityLabel.AutoSize = true;
            this.QualityLabel.Location = new System.Drawing.Point( 149, 61 );
            this.QualityLabel.Name = "QualityLabel";
            this.QualityLabel.Size = new System.Drawing.Size( 42, 13 );
            this.QualityLabel.TabIndex = 13;
            this.QualityLabel.Text = "Quality:";
            // 
            // BatchJPEGCompressor
            // 
            this.ClientSize = new System.Drawing.Size( 361, 132 );
            this.Controls.Add( this.QualityLabel );
            this.Controls.Add( this.ResolutionLabel );
            this.Controls.Add( this.OutputLabel );
            this.Controls.Add( this.InputLabel );
            this.Controls.Add( this.OutputBrowseButton );
            this.Controls.Add( this.CompressButton );
            this.Controls.Add( this.InputBrowseButton );
            this.Controls.Add( this.QualityTextBox );
            this.Controls.Add( this.ResolutionTextBox );
            this.Controls.Add( this.OutputTextBox );
            this.Controls.Add( this.InputTextBox );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BatchJPEGCompressor";
            this.Text = "Batch Image Compressor";
            this.Load += new System.EventHandler( this.BatchImageCompressorForm_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        private void BatchImageCompressorForm_Load( object sender, EventArgs e )
        {
            mImageCodecInfo = GetEncoderInfo( "image/jpeg" );
            mEncoderParameters = new EncoderParameters();
            ResolutionTextBox.Text = msDefaultResolution.ToString();
            QualityTextBox.Text = msDefaultQuality.ToString();
        }

        private void InputBrowseButton_Click( object sender, EventArgs e )
        {
            if ( InputBrowseDialog.ShowDialog() == DialogResult.OK )
            {
                InputTextBox.Text = InputBrowseDialog.SelectedPath;
            }
        }

        private void OutputBrowseButton_Click( object sender, EventArgs e )
        {
            if ( OutputBrowseDialog.ShowDialog() == DialogResult.OK )
            {
                OutputTextBox.Text = OutputBrowseDialog.SelectedPath;
            }
        }

        private void CompressButton_Click( object sender, EventArgs e )
        {
            String parameterValidationResult = ValidateParameters();
            if ( !String.IsNullOrEmpty( parameterValidationResult ) )
            {
                MessageBox.Show(
                    this,
                    parameterValidationResult,
                    "Batch Image Compressor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            try
            {
                CompressButton.Text = "Compression in Progress...";
                CompressButton.Enabled = false;
                Compress( InputTextBox.Text, OutputTextBox.Text );
            }
            catch ( Exception )
            {
            }
            finally
            {
                CompressButton.Enabled = true;
                CompressButton.Text = "Convert";
            }
        }

        private String ValidateParameters()
        {
            if ( String.IsNullOrEmpty( InputTextBox.Text ) )
            {
                return "Input directory cannot be empty.";
            }

            if ( String.IsNullOrEmpty( OutputTextBox.Text ) )
            {
                return "Output directory cannot be empty.";
            }

            if ( Directory.EnumerateFileSystemEntries( OutputTextBox.Text ).GetEnumerator().MoveNext() )
            {
                return "Output directory must be empty.";
            }

            if ( String.IsNullOrEmpty( ResolutionTextBox.Text ) )
            {
                return "Resolution cannot be empty!";
            }

            bool invalidResolution = false;
            try
            {
                int resolution = System.Convert.ToInt32( ResolutionTextBox.Text );
                invalidResolution = resolution < 1 || resolution > 100;
            }
            catch ( Exception )
            {
                invalidResolution = true;
            }

            if ( invalidResolution )
            {
                return "Resolution must be an integer in the range [1, 100].";
            }

            bool invalidQuality = false;
            try
            {
                int quality = System.Convert.ToInt32( QualityTextBox.Text );
                invalidQuality = quality < 0 || quality > 100;
            }
            catch ( Exception )
            {
                invalidQuality = true;
            }

            if ( invalidQuality )
            {
                return "Quality must be an integer in the range [0, 100].";
            }

            return null;
        }

        private void Compress( string inputDirectory, string outputDirectory )
        {
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
            mEncoderParameters.Param[0] = new EncoderParameter( encoder, System.Convert.ToInt32( QualityTextBox.Text ) );

            string[] imageFiles = Directory.GetFiles( inputDirectory );
            foreach ( string imageFile in imageFiles )
            {
                String extension = Path.GetExtension( imageFile );
                if ( !String.IsNullOrEmpty( extension ) && extension.ToLower().Equals( ".jpg" ) )
                {
                    using ( Image inImage = Image.FromFile( imageFile ) )
                    {
                        float quality = System.Convert.ToSingle( ResolutionTextBox.Text ) / 100.0f;
                        using ( Bitmap outImage = new Bitmap( (int)( inImage.Width * quality ), (int)( inImage.Height * quality ), PixelFormat.Format24bppRgb ) )
                        {
                            outImage.SetResolution( 72, 72 );
                            using ( Graphics graphics = Graphics.FromImage( outImage ) )
                            {
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                graphics.DrawImage( inImage, new Rectangle( 0, 0, outImage.Width, outImage.Height ), 0, 0, inImage.Width, inImage.Height, GraphicsUnit.Pixel );
                                outImage.Save( Path.Combine( outputDirectory, Path.GetFileName( imageFile ) ), mImageCodecInfo, mEncoderParameters );
                            }
                        }
                    }
                }
            }
        }

        private static ImageCodecInfo GetEncoderInfo( String mimeType )
        {
            foreach ( ImageCodecInfo imageCodecInfo in ImageCodecInfo.GetImageEncoders() )
            {
                if ( imageCodecInfo.MimeType == mimeType )
                {
                    return imageCodecInfo;
                }
            }

            return null;
        }
        #endregion

        #region Private Members
        private static int msDefaultResolution = 65;
        private static int msDefaultQuality = 85;
        private ImageCodecInfo mImageCodecInfo;
        private TextBox InputTextBox;
        private TextBox OutputTextBox;
        private TextBox ResolutionTextBox;
        private TextBox QualityTextBox;
        private Button InputBrowseButton;
        private Button CompressButton;
        private Button OutputBrowseButton;
        private Label InputLabel;
        private Label OutputLabel;
        private Label ResolutionLabel;
        private Label QualityLabel;
        private FolderBrowserDialog InputBrowseDialog;
        private FolderBrowserDialog OutputBrowseDialog;
        private EncoderParameters mEncoderParameters;
        #endregion
    }
}
