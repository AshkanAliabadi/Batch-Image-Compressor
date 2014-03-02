using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            this.ResolutionPercentTextBox = new System.Windows.Forms.TextBox();
            this.QualityTextBox = new System.Windows.Forms.TextBox();
            this.InputBrowseButton = new System.Windows.Forms.Button();
            this.CompressButton = new System.Windows.Forms.Button();
            this.OutputBrowseButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.QualityLabel = new System.Windows.Forms.Label();
            this.InputBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.OutputBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ResolutionGroupBox = new System.Windows.Forms.GroupBox();
            this.ResolutionDimensionTextBox = new System.Windows.Forms.TextBox();
            this.ResolutionDimensionRadioButton = new System.Windows.Forms.RadioButton();
            this.ResolutionPercentRadioButton = new System.Windows.Forms.RadioButton();
            this.ResolutionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point( 60, 6 );
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ReadOnly = true;
            this.InputTextBox.Size = new System.Drawing.Size( 296, 20 );
            this.InputTextBox.TabIndex = 1;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point( 60, 32 );
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size( 296, 20 );
            this.OutputTextBox.TabIndex = 3;
            // 
            // ResolutionPercentTextBox
            // 
            this.ResolutionPercentTextBox.Enabled = false;
            this.ResolutionPercentTextBox.Location = new System.Drawing.Point( 94, 46 );
            this.ResolutionPercentTextBox.MaxLength = 3;
            this.ResolutionPercentTextBox.Name = "ResolutionPercentTextBox";
            this.ResolutionPercentTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.ResolutionPercentTextBox.TabIndex = 2;
            // 
            // QualityTextBox
            // 
            this.QualityTextBox.Location = new System.Drawing.Point( 286, 76 );
            this.QualityTextBox.MaxLength = 3;
            this.QualityTextBox.Name = "QualityTextBox";
            this.QualityTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.QualityTextBox.TabIndex = 6;
            // 
            // InputBrowseButton
            // 
            this.InputBrowseButton.Location = new System.Drawing.Point( 362, 4 );
            this.InputBrowseButton.Name = "InputBrowseButton";
            this.InputBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.InputBrowseButton.TabIndex = 2;
            this.InputBrowseButton.Text = "Browse";
            this.InputBrowseButton.UseVisualStyleBackColor = true;
            this.InputBrowseButton.Click += new System.EventHandler( this.InputBrowseButton_Click );
            // 
            // CompressButton
            // 
            this.CompressButton.Location = new System.Drawing.Point( 12, 140 );
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size( 425, 23 );
            this.CompressButton.TabIndex = 7;
            this.CompressButton.Text = "Compress";
            this.CompressButton.UseVisualStyleBackColor = true;
            this.CompressButton.Click += new System.EventHandler( this.CompressButton_Click );
            // 
            // OutputBrowseButton
            // 
            this.OutputBrowseButton.Location = new System.Drawing.Point( 362, 30 );
            this.OutputBrowseButton.Name = "OutputBrowseButton";
            this.OutputBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.OutputBrowseButton.TabIndex = 4;
            this.OutputBrowseButton.Text = "Browse";
            this.OutputBrowseButton.UseVisualStyleBackColor = true;
            this.OutputBrowseButton.Click += new System.EventHandler( this.OutputBrowseButton_Click );
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point( 20, 9 );
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size( 34, 13 );
            this.InputLabel.TabIndex = 0;
            this.InputLabel.Text = "Input:";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point( 12, 35 );
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size( 42, 13 );
            this.OutputLabel.TabIndex = 0;
            this.OutputLabel.Text = "Output:";
            // 
            // QualityLabel
            // 
            this.QualityLabel.AutoSize = true;
            this.QualityLabel.Location = new System.Drawing.Point( 238, 79 );
            this.QualityLabel.Name = "QualityLabel";
            this.QualityLabel.Size = new System.Drawing.Size( 42, 13 );
            this.QualityLabel.TabIndex = 0;
            this.QualityLabel.Text = "Quality:";
            // 
            // ResolutionGroupBox
            // 
            this.ResolutionGroupBox.Controls.Add( this.ResolutionDimensionTextBox );
            this.ResolutionGroupBox.Controls.Add( this.ResolutionDimensionRadioButton );
            this.ResolutionGroupBox.Controls.Add( this.ResolutionPercentRadioButton );
            this.ResolutionGroupBox.Controls.Add( this.ResolutionPercentTextBox );
            this.ResolutionGroupBox.Location = new System.Drawing.Point( 60, 58 );
            this.ResolutionGroupBox.Name = "ResolutionGroupBox";
            this.ResolutionGroupBox.Size = new System.Drawing.Size( 170, 72 );
            this.ResolutionGroupBox.TabIndex = 5;
            this.ResolutionGroupBox.TabStop = false;
            this.ResolutionGroupBox.Text = "Resolution";
            // 
            // ResolutionDimensionTextBox
            // 
            this.ResolutionDimensionTextBox.Location = new System.Drawing.Point( 94, 18 );
            this.ResolutionDimensionTextBox.MaxLength = 4;
            this.ResolutionDimensionTextBox.Name = "ResolutionDimensionTextBox";
            this.ResolutionDimensionTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.ResolutionDimensionTextBox.TabIndex = 4;
            // 
            // ResolutionDimensionRadioButton
            // 
            this.ResolutionDimensionRadioButton.AutoSize = true;
            this.ResolutionDimensionRadioButton.Checked = true;
            this.ResolutionDimensionRadioButton.Location = new System.Drawing.Point( 11, 19 );
            this.ResolutionDimensionRadioButton.Name = "ResolutionDimensionRadioButton";
            this.ResolutionDimensionRadioButton.Size = new System.Drawing.Size( 77, 17 );
            this.ResolutionDimensionRadioButton.TabIndex = 3;
            this.ResolutionDimensionRadioButton.TabStop = true;
            this.ResolutionDimensionRadioButton.Text = "Dimension:";
            this.ResolutionDimensionRadioButton.UseVisualStyleBackColor = true;
            this.ResolutionDimensionRadioButton.CheckedChanged += new System.EventHandler( this.ResolutionDimensionRadioButton_CheckedChanged );
            // 
            // ResolutionPercentRadioButton
            // 
            this.ResolutionPercentRadioButton.AutoSize = true;
            this.ResolutionPercentRadioButton.Location = new System.Drawing.Point( 11, 47 );
            this.ResolutionPercentRadioButton.Name = "ResolutionPercentRadioButton";
            this.ResolutionPercentRadioButton.Size = new System.Drawing.Size( 65, 17 );
            this.ResolutionPercentRadioButton.TabIndex = 1;
            this.ResolutionPercentRadioButton.Text = "Percent:";
            this.ResolutionPercentRadioButton.UseVisualStyleBackColor = true;
            this.ResolutionPercentRadioButton.CheckedChanged += new System.EventHandler( this.ResolutionPercentRadioButton_CheckedChanged );
            // 
            // BatchJPEGCompressor
            // 
            this.ClientSize = new System.Drawing.Size( 449, 175 );
            this.Controls.Add( this.InputLabel );
            this.Controls.Add( this.InputTextBox );
            this.Controls.Add( this.InputBrowseButton );
            this.Controls.Add( this.OutputLabel );
            this.Controls.Add( this.OutputTextBox );
            this.Controls.Add( this.OutputBrowseButton );
            this.Controls.Add( this.ResolutionGroupBox );
            this.Controls.Add( this.QualityLabel );
            this.Controls.Add( this.QualityTextBox );
            this.Controls.Add( this.CompressButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BatchJPEGCompressor";
            this.Text = "Batch JPEG Compressor";
            this.Load += new System.EventHandler( this.BatchImageCompressorForm_Load );
            this.ResolutionGroupBox.ResumeLayout( false );
            this.ResolutionGroupBox.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        private void BatchImageCompressorForm_Load( object sender, EventArgs e )
        {
            ResolutionDimensionTextBox.Text = msDefaultResolutionDimension.ToString();
            ResolutionPercentTextBox.Text = msDefaultResolutionPercent.ToString();
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

        private void ResolutionDimensionRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            ResolutionDimensionTextBox.Enabled = true;
            ResolutionPercentTextBox.Enabled = false;
        }

        private void ResolutionPercentRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            ResolutionDimensionTextBox.Enabled = false;
            ResolutionPercentTextBox.Enabled = true;
        }

        private void CompressButton_Click( object sender, EventArgs e )
        {
            String parameterValidationResult = ValidateParameters();
            if ( !String.IsNullOrEmpty( parameterValidationResult ) )
            {
                MessageBox.Show(
                    this,
                    parameterValidationResult,
                    "Batch JPEG Compressor",
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
            catch ( Exception ex )
            {
                MessageBox.Show(
                   this,
                   ex.ToString(),
                   "Batch JPEG Compressor",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
               );
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
                return "Invalid input directory!";
            }

            if ( String.IsNullOrEmpty( OutputTextBox.Text ) )
            {
                return "Invalid output directory!";
            }

            if ( Directory.EnumerateFileSystemEntries( OutputTextBox.Text ).GetEnumerator().MoveNext() )
            {
                return "To avoid overriding existing files, output directory is required to be empty.";
            }

            string invalidResolutionMessage = null;
            try
            {
                if ( ResolutionDimensionRadioButton.Enabled )
                {
                    int resolution = System.Convert.ToInt32( ResolutionDimensionTextBox.Text );
                    if ( resolution < 1 || resolution > 9999 )
                    {
                        invalidResolutionMessage = "Resolution dimension must be an integer in the range [1, 9999]";
                    }
                }

                if ( ResolutionPercentRadioButton.Enabled )
                {
                    int resolution = System.Convert.ToInt32( ResolutionPercentTextBox.Text );
                    if ( resolution < 1 || resolution > 100 )
                    {
                        invalidResolutionMessage = "Resolution percentage must be an integer in the range [1, 100]";
                    }
                }
            }
            catch ( Exception )
            {
            }

            if ( !string.IsNullOrEmpty( invalidResolutionMessage ) )
            {
                return invalidResolutionMessage;
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
            ImageCodecInfo imageCodecInfo = GetEncoderInfo( "image/jpeg" );

            EncoderParameters encoderParameters = new EncoderParameters();
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
            encoderParameters.Param[0] = new EncoderParameter( encoder, System.Convert.ToInt32( QualityTextBox.Text ) );

            CompressDirectory( imageCodecInfo, encoderParameters, inputDirectory, outputDirectory );
        }

        private void CompressDirectory( ImageCodecInfo imageCodecInfo, EncoderParameters encoderParameters, string inputDirectory, string outputDirectory )
        {
            string[] imageFiles = Directory.GetFiles( inputDirectory );
            Parallel.ForEach(
                imageFiles,
                imageFile => CompressFile( imageCodecInfo, encoderParameters, imageFile, outputDirectory )
            );

            string[] directories = Directory.GetDirectories( inputDirectory );
            foreach ( string directory in directories )
            {
                CompressDirectory( imageCodecInfo, encoderParameters, directory, outputDirectory );
            }
        }

        private void CompressFile( ImageCodecInfo imageCodecInfo, EncoderParameters encoderParameters, string imageFile, string outputDirectory )
        {
            String extension = Path.GetExtension( imageFile ).ToLower();
            if ( String.IsNullOrEmpty( extension ) || !extension.Equals( ".jpg" ) )
            {
                return;
            }

            using ( Image inImage = Image.FromFile( imageFile ) )
            {
                int width = inImage.Width;
                int height = inImage.Height;
                AdjustResolution( ref width, ref height );

                using ( Bitmap outImage = new Bitmap( width, height, PixelFormat.Format24bppRgb ) )
                {
                    foreach ( PropertyItem propertyItem in inImage.PropertyItems )
                    {
                        outImage.SetPropertyItem( propertyItem );
                    }

                    float xdpi = BitConverter.ToInt32( inImage.GetPropertyItem( 0x011A ).Value, 0 );
                    float ydpi = BitConverter.ToInt32( inImage.GetPropertyItem( 0x011B ).Value, 0 );
                    outImage.SetResolution( xdpi, ydpi );

                    using ( Graphics graphics = Graphics.FromImage( outImage ) )
                    {
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        graphics.DrawImage(
                            inImage,
                            new Rectangle(
                                0, 0,
                                outImage.Width, outImage.Height
                            ),
                            0, 0,
                            inImage.Width, inImage.Height,
                            GraphicsUnit.Pixel
                        );

                        string dateTime = Encoding.UTF8.GetString( inImage.GetPropertyItem( 0x0132 ).Value );
                        string filename = RemoveInvalidCharacters( dateTime.Replace( ':', '-' ) ) + extension;
                        outImage.Save( Path.Combine( outputDirectory, filename ), imageCodecInfo, encoderParameters );
                    }
                }
            }
        }

        private void AdjustResolution( ref int width, ref int height )
        {
            if ( ResolutionDimensionTextBox.Enabled )
            {
                float shortEdge = Math.Min( width, height );
                float longEdge = Math.Max( width, height );

                float dimension = System.Convert.ToSingle( ResolutionDimensionTextBox.Text );
                if ( dimension < longEdge )
                {
                    shortEdge *= ( dimension / longEdge );
                    longEdge = dimension;

                    if ( width < height )
                    {
                        width = ( int ) shortEdge;
                        height = ( int ) longEdge;
                    }
                    else
                    {
                        width = ( int ) longEdge;
                        height = ( int ) shortEdge;
                    }
                }
            }
            else if ( ResolutionPercentTextBox.Enabled )
            {
                float factor = System.Convert.ToSingle( ResolutionPercentTextBox.Text ) / 100.0f;
                width = ( int ) ( width * factor );
                height = ( int ) ( height * factor );
            }
        }

        private static string RemoveInvalidCharacters( string filename )
        {
            char[] invalidCharacters = Path.GetInvalidFileNameChars();
            return Regex.Replace( filename, "[" + Regex.Escape( new string( invalidCharacters ) ) + "]", String.Empty );
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
        private static int msDefaultResolutionDimension = 1400;
        private static int msDefaultResolutionPercent = 65;
        private static int msDefaultQuality = 85;
        private TextBox InputTextBox;
        private TextBox OutputTextBox;
        private TextBox ResolutionPercentTextBox;
        private TextBox QualityTextBox;
        private Button InputBrowseButton;
        private Button CompressButton;
        private Button OutputBrowseButton;
        private Label InputLabel;
        private Label OutputLabel;
        private Label QualityLabel;
        private FolderBrowserDialog InputBrowseDialog;
        private GroupBox ResolutionGroupBox;
        private TextBox ResolutionDimensionTextBox;
        private RadioButton ResolutionDimensionRadioButton;
        private RadioButton ResolutionPercentRadioButton;
        private FolderBrowserDialog OutputBrowseDialog;
        #endregion
    }
}
