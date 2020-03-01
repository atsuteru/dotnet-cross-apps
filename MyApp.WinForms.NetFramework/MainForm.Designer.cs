namespace MyApp.WinForms.NetFramework
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.RoutedControlHost = new ReactiveUI.Winforms.RoutedControlHost();
            this.SuspendLayout();
            // 
            // RoutedControlHost
            // 
            this.RoutedControlHost.DefaultContent = null;
            this.RoutedControlHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoutedControlHost.Location = new System.Drawing.Point(0, 0);
            this.RoutedControlHost.Name = "RoutedControlHost";
            this.RoutedControlHost.Router = null;
            this.RoutedControlHost.Size = new System.Drawing.Size(986, 546);
            this.RoutedControlHost.TabIndex = 0;
            this.RoutedControlHost.ViewLocator = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 546);
            this.Controls.Add(this.RoutedControlHost);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ReactiveUI.Winforms.RoutedControlHost RoutedControlHost;
    }
}

