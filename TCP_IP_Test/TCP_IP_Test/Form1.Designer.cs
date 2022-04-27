
namespace TCP_IP_Test
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_sumsung = new System.Windows.Forms.Button();
            this.bt_sk = new System.Windows.Forms.Button();
            this.rtxLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bt_sumsung
            // 
            this.bt_sumsung.Location = new System.Drawing.Point(12, 118);
            this.bt_sumsung.Name = "bt_sumsung";
            this.bt_sumsung.Size = new System.Drawing.Size(230, 100);
            this.bt_sumsung.TabIndex = 4;
            this.bt_sumsung.Text = "삼성";
            this.bt_sumsung.UseVisualStyleBackColor = true;
            this.bt_sumsung.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_sumsung_MouseDown);
            this.bt_sumsung.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_sumsung_MouseUp);
            // 
            // bt_sk
            // 
            this.bt_sk.Location = new System.Drawing.Point(12, 224);
            this.bt_sk.Name = "bt_sk";
            this.bt_sk.Size = new System.Drawing.Size(230, 100);
            this.bt_sk.TabIndex = 5;
            this.bt_sk.Text = "SK하이닉스";
            this.bt_sk.UseVisualStyleBackColor = true;
            this.bt_sk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_sk_MouseDown);
            this.bt_sk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_sk_MouseUp);
            // 
            // rtxLog
            // 
            this.rtxLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.rtxLog.ForeColor = System.Drawing.SystemColors.Window;
            this.rtxLog.Location = new System.Drawing.Point(248, 12);
            this.rtxLog.Name = "rtxLog";
            this.rtxLog.Size = new System.Drawing.Size(272, 312);
            this.rtxLog.TabIndex = 6;
            this.rtxLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 336);
            this.Controls.Add(this.rtxLog);
            this.Controls.Add(this.bt_sk);
            this.Controls.Add(this.bt_sumsung);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_sumsung;
        private System.Windows.Forms.Button bt_sk;
        private System.Windows.Forms.RichTextBox rtxLog;
    }
}

