using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchImageCompressor
{
    public partial class BatchImageCompressor : Form
    {
        #region Public Methods
        public BatchImageCompressor()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void InitializeComponent()
        {
            this.mInputLabel = new System.Windows.Forms.Label();
            this.mInputTextBox = new System.Windows.Forms.TextBox();
            this.mInputBrowseButton = new System.Windows.Forms.Button();
            this.mInputBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mOutputLabel = new System.Windows.Forms.Label();
            this.mOutputTextBox = new System.Windows.Forms.TextBox();
            this.mOutputBrowseButton = new System.Windows.Forms.Button();
            this.mOutputBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mProblematicLabel = new System.Windows.Forms.Label();
            this.mProblematicTextBox = new System.Windows.Forms.TextBox();
            this.mProblematicBrowseButton = new System.Windows.Forms.Button();
            this.mProblematicBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mResolutionGroupBox = new System.Windows.Forms.GroupBox();
            this.mResolutionDimensionTextBox = new System.Windows.Forms.TextBox();
            this.mResolutionDimensionRadioButton = new System.Windows.Forms.RadioButton();
            this.mResolutionPercentRadioButton = new System.Windows.Forms.RadioButton();
            this.mResolutionPercentTextBox = new System.Windows.Forms.TextBox();
            this.mQualityLabel = new System.Windows.Forms.Label();
            this.mQualityTextBox = new System.Windows.Forms.TextBox();
            this.mCompressButton = new System.Windows.Forms.Button();
            this.mBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mResolutionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mInputLabel
            // 
            this.mInputLabel.AutoSize = true;
            this.mInputLabel.Location = new System.Drawing.Point( 34, 10 );
            this.mInputLabel.Name = "mInputLabel";
            this.mInputLabel.Size = new System.Drawing.Size( 34, 13 );
            this.mInputLabel.TabIndex = 0;
            this.mInputLabel.Text = "Input:";
            // 
            // mInputTextBox
            // 
            this.mInputTextBox.Location = new System.Drawing.Point( 74, 7 );
            this.mInputTextBox.Name = "mInputTextBox";
            this.mInputTextBox.ReadOnly = true;
            this.mInputTextBox.Size = new System.Drawing.Size( 296, 20 );
            this.mInputTextBox.TabIndex = 0;
            this.mInputTextBox.TabStop = false;
            // 
            // mInputBrowseButton
            // 
            this.mInputBrowseButton.Location = new System.Drawing.Point( 376, 4 );
            this.mInputBrowseButton.Name = "mInputBrowseButton";
            this.mInputBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.mInputBrowseButton.TabIndex = 1;
            this.mInputBrowseButton.Text = "Browse";
            this.mInputBrowseButton.UseVisualStyleBackColor = true;
            this.mInputBrowseButton.Click += new System.EventHandler( this.InputBrowseButton_Click );
            // 
            // mOutputLabel
            // 
            this.mOutputLabel.AutoSize = true;
            this.mOutputLabel.Location = new System.Drawing.Point( 26, 37 );
            this.mOutputLabel.Name = "mOutputLabel";
            this.mOutputLabel.Size = new System.Drawing.Size( 42, 13 );
            this.mOutputLabel.TabIndex = 0;
            this.mOutputLabel.Text = "Output:";
            // 
            // mOutputTextBox
            // 
            this.mOutputTextBox.Location = new System.Drawing.Point( 74, 34 );
            this.mOutputTextBox.Name = "mOutputTextBox";
            this.mOutputTextBox.ReadOnly = true;
            this.mOutputTextBox.Size = new System.Drawing.Size( 296, 20 );
            this.mOutputTextBox.TabIndex = 0;
            this.mOutputTextBox.TabStop = false;
            // 
            // mOutputBrowseButton
            // 
            this.mOutputBrowseButton.Location = new System.Drawing.Point( 376, 31 );
            this.mOutputBrowseButton.Name = "mOutputBrowseButton";
            this.mOutputBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.mOutputBrowseButton.TabIndex = 2;
            this.mOutputBrowseButton.Text = "Browse";
            this.mOutputBrowseButton.UseVisualStyleBackColor = true;
            this.mOutputBrowseButton.Click += new System.EventHandler( this.OutputBrowseButton_Click );
            // 
            // mProblematicLabel
            // 
            this.mProblematicLabel.AutoSize = true;
            this.mProblematicLabel.Location = new System.Drawing.Point( 3, 63 );
            this.mProblematicLabel.Name = "mProblematicLabel";
            this.mProblematicLabel.Size = new System.Drawing.Size( 65, 13 );
            this.mProblematicLabel.TabIndex = 0;
            this.mProblematicLabel.Text = "Problematic:";
            // 
            // mProblematicTextBox
            // 
            this.mProblematicTextBox.Location = new System.Drawing.Point( 74, 60 );
            this.mProblematicTextBox.Name = "mProblematicTextBox";
            this.mProblematicTextBox.ReadOnly = true;
            this.mProblematicTextBox.Size = new System.Drawing.Size( 296, 20 );
            this.mProblematicTextBox.TabIndex = 0;
            this.mProblematicTextBox.TabStop = false;
            // 
            // mProblematicBrowseButton
            // 
            this.mProblematicBrowseButton.Location = new System.Drawing.Point( 376, 57 );
            this.mProblematicBrowseButton.Name = "mProblematicBrowseButton";
            this.mProblematicBrowseButton.Size = new System.Drawing.Size( 75, 23 );
            this.mProblematicBrowseButton.TabIndex = 3;
            this.mProblematicBrowseButton.Text = "Browse";
            this.mProblematicBrowseButton.UseVisualStyleBackColor = true;
            this.mProblematicBrowseButton.Click += new System.EventHandler( this.mProblematicBrowseButton_Click );
            // 
            // mResolutionGroupBox
            // 
            this.mResolutionGroupBox.Controls.Add( this.mResolutionDimensionTextBox );
            this.mResolutionGroupBox.Controls.Add( this.mResolutionDimensionRadioButton );
            this.mResolutionGroupBox.Controls.Add( this.mResolutionPercentRadioButton );
            this.mResolutionGroupBox.Controls.Add( this.mResolutionPercentTextBox );
            this.mResolutionGroupBox.Location = new System.Drawing.Point( 74, 86 );
            this.mResolutionGroupBox.Name = "mResolutionGroupBox";
            this.mResolutionGroupBox.Size = new System.Drawing.Size( 170, 72 );
            this.mResolutionGroupBox.TabIndex = 5;
            this.mResolutionGroupBox.TabStop = false;
            this.mResolutionGroupBox.Text = "Resolution";
            // 
            // mResolutionDimensionTextBox
            // 
            this.mResolutionDimensionTextBox.Location = new System.Drawing.Point( 94, 18 );
            this.mResolutionDimensionTextBox.MaxLength = 4;
            this.mResolutionDimensionTextBox.Name = "mResolutionDimensionTextBox";
            this.mResolutionDimensionTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.mResolutionDimensionTextBox.TabIndex = 5;
            // 
            // mResolutionDimensionRadioButton
            // 
            this.mResolutionDimensionRadioButton.AutoSize = true;
            this.mResolutionDimensionRadioButton.Checked = true;
            this.mResolutionDimensionRadioButton.Location = new System.Drawing.Point( 11, 19 );
            this.mResolutionDimensionRadioButton.Name = "mResolutionDimensionRadioButton";
            this.mResolutionDimensionRadioButton.Size = new System.Drawing.Size( 77, 17 );
            this.mResolutionDimensionRadioButton.TabIndex = 4;
            this.mResolutionDimensionRadioButton.TabStop = true;
            this.mResolutionDimensionRadioButton.Text = "Dimension:";
            this.mResolutionDimensionRadioButton.UseVisualStyleBackColor = true;
            this.mResolutionDimensionRadioButton.CheckedChanged += new System.EventHandler( this.ResolutionDimensionRadioButton_CheckedChanged );
            // 
            // mResolutionPercentRadioButton
            // 
            this.mResolutionPercentRadioButton.AutoSize = true;
            this.mResolutionPercentRadioButton.Location = new System.Drawing.Point( 11, 47 );
            this.mResolutionPercentRadioButton.Name = "mResolutionPercentRadioButton";
            this.mResolutionPercentRadioButton.Size = new System.Drawing.Size( 65, 17 );
            this.mResolutionPercentRadioButton.TabIndex = 3;
            this.mResolutionPercentRadioButton.Text = "Percent:";
            this.mResolutionPercentRadioButton.UseVisualStyleBackColor = true;
            this.mResolutionPercentRadioButton.CheckedChanged += new System.EventHandler( this.ResolutionPercentRadioButton_CheckedChanged );
            // 
            // mResolutionPercentTextBox
            // 
            this.mResolutionPercentTextBox.Enabled = false;
            this.mResolutionPercentTextBox.Location = new System.Drawing.Point( 94, 46 );
            this.mResolutionPercentTextBox.MaxLength = 3;
            this.mResolutionPercentTextBox.Name = "mResolutionPercentTextBox";
            this.mResolutionPercentTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.mResolutionPercentTextBox.TabIndex = 6;
            // 
            // mQualityLabel
            // 
            this.mQualityLabel.AutoSize = true;
            this.mQualityLabel.Location = new System.Drawing.Point( 252, 106 );
            this.mQualityLabel.Name = "mQualityLabel";
            this.mQualityLabel.Size = new System.Drawing.Size( 42, 13 );
            this.mQualityLabel.TabIndex = 0;
            this.mQualityLabel.Text = "Quality:";
            // 
            // mQualityTextBox
            // 
            this.mQualityTextBox.Location = new System.Drawing.Point( 300, 103 );
            this.mQualityTextBox.MaxLength = 3;
            this.mQualityTextBox.Name = "mQualityTextBox";
            this.mQualityTextBox.Size = new System.Drawing.Size( 70, 20 );
            this.mQualityTextBox.TabIndex = 7;
            // 
            // mCompressButton
            // 
            this.mCompressButton.Location = new System.Drawing.Point( 8, 164 );
            this.mCompressButton.Name = "mCompressButton";
            this.mCompressButton.Size = new System.Drawing.Size( 441, 23 );
            this.mCompressButton.TabIndex = 8;
            this.mCompressButton.Text = "Compress";
            this.mCompressButton.UseVisualStyleBackColor = true;
            this.mCompressButton.Click += new System.EventHandler( this.CompressButton_Click );
            // 
            // mBackgroundWorker
            // 
            this.mBackgroundWorker.WorkerReportsProgress = true;
            this.mBackgroundWorker.WorkerSupportsCancellation = true;
            this.mBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.mBackgroundWorker_DoWork );
            this.mBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler( this.mBackgroundWorker_ProgressChanged );
            this.mBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.mBackgroundWorker_RunWorkerCompleted );
            // 
            // BatchImageCompressor
            // 
            this.ClientSize = new System.Drawing.Size( 461, 194 );
            this.Controls.Add( this.mProblematicBrowseButton );
            this.Controls.Add( this.mProblematicLabel );
            this.Controls.Add( this.mProblematicTextBox );
            this.Controls.Add( this.mInputLabel );
            this.Controls.Add( this.mInputTextBox );
            this.Controls.Add( this.mInputBrowseButton );
            this.Controls.Add( this.mOutputLabel );
            this.Controls.Add( this.mOutputTextBox );
            this.Controls.Add( this.mOutputBrowseButton );
            this.Controls.Add( this.mResolutionGroupBox );
            this.Controls.Add( this.mQualityLabel );
            this.Controls.Add( this.mQualityTextBox );
            this.Controls.Add( this.mCompressButton );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BatchImageCompressor";
            this.Text = "Batch Image Compressor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.BatchImageCompressorForm_Closing );
            this.Load += new System.EventHandler( this.BatchImageCompressorForm_Load );
            this.mResolutionGroupBox.ResumeLayout( false );
            this.mResolutionGroupBox.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        private void BatchImageCompressorForm_Load( object sender, EventArgs e )
        {
            mResolutionDimensionTextBox.Text = mDefaultResolutionDimension.ToString();
            mResolutionPercentTextBox.Text = mDefaultResolutionPercent.ToString();
            mQualityTextBox.Text = mDefaultQuality.ToString();

            mParallelOptions = new ParallelOptions();
            mParallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            this.CenterToParent();
        }

        private void BatchImageCompressorForm_Closing( object sender, FormClosingEventArgs e )
        {
            if ( mBackgroundWorker.IsBusy && !PromptCancel() )
            {
                e.Cancel = true;
            }
        }

        private void InputBrowseButton_Click( object sender, EventArgs e )
        {
            if ( mInputBrowseDialog.ShowDialog() == DialogResult.OK )
            {
                mInputTextBox.Text = mInputBrowseDialog.SelectedPath;
            }
        }

        private void OutputBrowseButton_Click( object sender, EventArgs e )
        {
            if ( mOutputBrowseDialog.ShowDialog() == DialogResult.OK )
            {
                mOutputTextBox.Text = mOutputBrowseDialog.SelectedPath;
            }
        }

        private void mProblematicBrowseButton_Click( object sender, EventArgs e )
        {
            if ( mProblematicBrowseDialog.ShowDialog() == DialogResult.OK )
            {
                mProblematicTextBox.Text = mProblematicBrowseDialog.SelectedPath;
            }
        }

        private void ResolutionDimensionRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            mResolutionDimensionTextBox.Enabled = true;
            mResolutionPercentTextBox.Enabled = false;
        }

        private void ResolutionPercentRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            mResolutionDimensionTextBox.Enabled = false;
            mResolutionPercentTextBox.Enabled = true;
        }

        private void CompressButton_Click( object sender, EventArgs e )
        {
            if ( mBackgroundWorker.IsBusy )
            {
                PromptCancel();
            }
            else
            {
                String validationResult = ValidateUserInput();
                if ( !String.IsNullOrEmpty( validationResult ) )
                {
                    MessageBox.Show(
                        this,
                        validationResult,
                        msTitleBarText,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                mBackgroundWorker.RunWorkerAsync();
                mCompressButton.Text = "Cancel";
            }
        }

        private void mBackgroundWorker_DoWork( object sender, DoWorkEventArgs e )
        {
            ResetStatistics( mInputTextBox.Text );

            Compress( mInputTextBox.Text, mOutputTextBox.Text );

            if ( mBackgroundWorker.CancellationPending )
            {
                e.Cancel = true;
            }
        }

        private void mBackgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            this.Text = msTitleBarText + " - " + ( e.ProgressPercentage.ToString() + "%" );
        }

        private void mBackgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            string message = null;
            MessageBoxIcon icon;

            if ( e.Error != null )
            {
                message = e.Error.Message;
                icon = MessageBoxIcon.Error;
            }
            else if ( e.Cancelled )
            {
                message = "Canceled!";
                icon = MessageBoxIcon.Warning;
            }
            else
            {
                message = "Completed.";
                icon = MessageBoxIcon.Information;
            }

            MessageBox.Show(
                this,
                message,
                msTitleBarText,
                MessageBoxButtons.OK,
                icon
            );

            this.Text = msTitleBarText;
            mCompressButton.Text = "Compress";
        }

        private String ValidateUserInput()
        {
            if ( String.IsNullOrEmpty( mInputTextBox.Text ) )
            {
                return "The input directory cannot be empty! Please choose a valid directory whose images you want compressed.";
            }

            if ( String.IsNullOrEmpty( mOutputTextBox.Text ) )
            {
                return "The output directory cannot be empty! Please choose a valid directory to where you want compressed images stored.";
            }

            if ( String.IsNullOrEmpty( mProblematicTextBox.Text ) )
            {
                return "The problematic directory cannot be empty! Please choose a valid directory to copy all the problematic images to. " +
                       "The images are considered problematic if the Batch Image Compressor fails to compress them for whatever reason.";
            }

            if ( Directory.EnumerateFileSystemEntries( mOutputTextBox.Text ).GetEnumerator().MoveNext() )
            {
                return "To avoid overriding existing files, the output directory is required to be empty.";
            }

            if ( Directory.EnumerateFileSystemEntries( mProblematicTextBox.Text ).GetEnumerator().MoveNext() )
            {
                return "To avoid overriding existing files, the problematic directory is required to be empty.";
            }

            string invalidResolutionMessage = null;
            try
            {
                if ( mResolutionDimensionRadioButton.Enabled )
                {
                    int resolution = System.Convert.ToInt32( mResolutionDimensionTextBox.Text );
                    if ( resolution < 1 || resolution > 9999 )
                    {
                        invalidResolutionMessage = "Resolution dimension must be an integer in the range [1, 9999].";
                    }
                }

                if ( mResolutionPercentRadioButton.Enabled )
                {
                    int resolution = System.Convert.ToInt32( mResolutionPercentTextBox.Text );
                    if ( resolution < 1 || resolution > 100 )
                    {
                        invalidResolutionMessage = "Resolution percentage must be an integer in the range [1, 100].";
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
                int quality = System.Convert.ToInt32( mQualityTextBox.Text );
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

        private void ResetStatistics( string inputDirectory )
        {
            GetImageCount( inputDirectory, ref mImageCount );
            mCompressedCount = 0;
        }

        private void UpdateStatistics()
        {
            Interlocked.Add( ref mCompressedCount, 100 );
            /* 32-bit read is atomic in .NET's memory model. */
            mBackgroundWorker.ReportProgress( mCompressedCount / mImageCount );
        }

        private void Compress( string inputDirectory, string outputDirectory )
        {
            using ( EncoderParameters encoderParameters = new EncoderParameters() )
            {
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;
                using ( encoderParameters.Param[0] = new EncoderParameter( encoder, System.Convert.ToInt32( mQualityTextBox.Text ) ) )
                {
                    Compress( inputDirectory, outputDirectory, encoderParameters );
                }
            }
        }

        private void Compress( string inputDirectory, string outputDirectory, EncoderParameters encoderParameters )
        {
            if ( mBackgroundWorker.CancellationPending )
            {
                return;
            }

            Parallel.ForEach(
                Directory.GetFiles( inputDirectory ),
                mParallelOptions,
                ( file, loop ) =>
                {
                    if ( mBackgroundWorker.CancellationPending )
                    {
                        loop.Stop();
                    }

                    if ( CanCompress( file ) )
                    {
                        using ( Image image = Image.FromFile( file ) )
                        {
                            try
                            {
                                Compress( image, outputDirectory, encoderParameters );
                                UpdateStatistics();
                            }
                            catch ( Exception )
                            {
                                File.Copy( file, Path.Combine( mProblematicTextBox.Text, Path.GetFileName( file ) ) );
                            }
                        }
                    }
                }
            );

            if ( mBackgroundWorker.CancellationPending )
            {
                return;
            }

            string[] directories = Directory.GetDirectories( inputDirectory );
            foreach ( string directory in directories )
            {
                Compress( directory, outputDirectory, encoderParameters );
            }
        }

        private void Compress( Image image, string outputDirectory, EncoderParameters encoderParameters )
        {
            int width = image.Width;
            int height = image.Height;
            AdjustResolution( ref width, ref height );

            using ( Bitmap bitmap = new Bitmap( width, height, PixelFormat.Format24bppRgb ) )
            {
                foreach ( PropertyItem propertyItem in image.PropertyItems )
                {
                    bitmap.SetPropertyItem( propertyItem );
                }

                try
                {
                    float xdpi = BitConverter.ToInt32( image.GetPropertyItem( 0x011A ).Value, 0 );
                    float ydpi = BitConverter.ToInt32( image.GetPropertyItem( 0x011B ).Value, 0 );
                    bitmap.SetResolution( xdpi, ydpi );
                }
                catch ( ArgumentException )
                {
                    ;
                }

                using ( Graphics graphics = Graphics.FromImage( bitmap ) )
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;

                    graphics.DrawImage(
                        image,
                        new Rectangle(
                            0, 0,
                            bitmap.Width, bitmap.Height
                        ),
                        0, 0,
                        image.Width, image.Height,
                        GraphicsUnit.Pixel
                    );

                    bitmap.Save(
                        Path.Combine( outputDirectory, GetImageName( image ) ),
                        msImageCodecInfo,
                        encoderParameters
                    );
                }
            }
        }

        private void AdjustResolution( ref int width, ref int height )
        {
            if ( mResolutionDimensionTextBox.Enabled )
            {
                float shortEdge = Math.Min( width, height );
                float longEdge = Math.Max( width, height );

                float dimension = System.Convert.ToSingle( mResolutionDimensionTextBox.Text );
                if ( dimension < longEdge )
                {
                    shortEdge *= ( dimension / longEdge );
                    longEdge = dimension;

                    if ( width < height )
                    {
                        width = (int)shortEdge;
                        height = (int)longEdge;
                    }
                    else
                    {
                        width = (int)longEdge;
                        height = (int)shortEdge;
                    }
                }
            }
            else if ( mResolutionPercentTextBox.Enabled )
            {
                float factor = System.Convert.ToSingle( mResolutionPercentTextBox.Text ) / 100.0f;
                width = (int)( width * factor );
                height = (int)( height * factor );
            }
        }

        private bool PromptCancel()
        {
            DialogResult cancelDialogResult = MessageBox.Show(
                this,
                "Are you sure you want to cancel?",
                msTitleBarText,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            bool shouldCancel = ( cancelDialogResult == DialogResult.Yes );
            if ( shouldCancel )
            {
                mBackgroundWorker.CancelAsync();
                mCompressButton.Text = "Compress";
            }

            return shouldCancel;
        }

        private static bool CanCompress( string file )
        {
            String extension = Path.GetExtension( file ).ToLower();
            return !String.IsNullOrEmpty( extension ) &&
                (
                    extension.Equals( ".jpg" ) ||
                    extension.Equals( ".jpeg" ) ||
                    extension.Equals( ".bmp" ) ||
                    extension.Equals( ".png" ) ||
                    extension.Equals( ".gif" ) ||
                    extension.Equals( ".tiff" )
                );
        }

        private static void GetImageCount( string inputDirectory, ref int count )
        {
            string[] files = Directory.GetFiles( inputDirectory );
            foreach ( string file in files )
            {
                if ( CanCompress( file ) )
                {
                    ++count;
                }
            }

            string[] directories = Directory.GetDirectories( inputDirectory );
            foreach ( string directory in directories )
            {
                GetImageCount( directory, ref count );
            }
        }

        private static string GetImageName( Image image )
        {
            string dateTime = Encoding.UTF8.GetString( GetDateTime( image ).Value );
            return ParseDateTime( dateTime ).ToString( "yyyy-MM-dd_HH-mm-ss" ) + ".jpg";
        }

        private static PropertyItem GetDateTime( Image image )
        {
            foreach ( int tag in msTags )
            {
                try
                {
                    return image.GetPropertyItem( tag );
                }
                catch ( ArgumentException )
                {
                    continue;
                }
            }

            return null;
        }

        private static DateTime ParseDateTime( string dateTime )
        {
            foreach ( string format in msFormats )
            {
                try
                {
                    return DateTime.ParseExact(
                        dateTime,
                        format,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None
                    );
                }
                catch ( ArgumentException )
                {
                    continue;
                }
            }

            return DateTime.Parse(
                dateTime,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None
            );
        }

        private static ImageCodecInfo GetEncoderInfo( ImageFormat format )
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach ( ImageCodecInfo codec in codecs )
            {
                if ( codec.FormatID == format.Guid )
                {
                    return codec;
                }
            }

            return null;
        }
        #endregion

        #region Private Members
        private static readonly string msTitleBarText = "Batch Image Compressor";
        private static readonly ImageCodecInfo msImageCodecInfo = GetEncoderInfo( ImageFormat.Jpeg );
        private static readonly int[] msTags = new int[] { 0x9003, 0x0132 };
        private static readonly string[] msFormats = new string[] { "yyyy':'MM':'dd HH':'mm':'ss\0" };

        private const int mDefaultResolutionDimension = 1400;
        private const int mDefaultResolutionPercent = 65;
        private const int mDefaultQuality = 85;

        private Label mInputLabel;
        private TextBox mInputTextBox;
        private Button mInputBrowseButton;
        private FolderBrowserDialog mInputBrowseDialog;
        private Label mOutputLabel;
        private TextBox mOutputTextBox;
        private Button mOutputBrowseButton;
        private FolderBrowserDialog mOutputBrowseDialog;
        private Label mProblematicLabel;
        private TextBox mProblematicTextBox;
        private Button mProblematicBrowseButton;
        private FolderBrowserDialog mProblematicBrowseDialog;
        private GroupBox mResolutionGroupBox;
        private RadioButton mResolutionDimensionRadioButton;
        private TextBox mResolutionDimensionTextBox;
        private RadioButton mResolutionPercentRadioButton;
        private TextBox mResolutionPercentTextBox;
        private Label mQualityLabel;
        private TextBox mQualityTextBox;
        private Button mCompressButton;
        private BackgroundWorker mBackgroundWorker;

        private ParallelOptions mParallelOptions;
        private int mImageCount;
        private int mCompressedCount;

        #endregion
    }
}
