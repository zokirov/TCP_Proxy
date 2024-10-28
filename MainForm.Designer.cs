namespace TCP_Proxy
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            b_startserver = new Button();
            tb_port = new TextBox();
            lb_port = new Label();
            rb_log = new RichTextBox();
            b_connect = new Button();
            tb_message = new TextBox();
            tb_server = new TextBox();
            b_send = new Button();
            SuspendLayout();
            // 
            // b_startserver
            // 
            b_startserver.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            b_startserver.Location = new Point(237, 19);
            b_startserver.Margin = new Padding(2);
            b_startserver.Name = "b_startserver";
            b_startserver.Size = new Size(228, 74);
            b_startserver.TabIndex = 0;
            b_startserver.Text = "StartServer";
            b_startserver.UseVisualStyleBackColor = true;
            b_startserver.Click += b_startserver_Click;
            // 
            // tb_port
            // 
            tb_port.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tb_port.Location = new Point(94, 44);
            tb_port.Margin = new Padding(2);
            tb_port.Name = "tb_port";
            tb_port.Size = new Size(106, 32);
            tb_port.TabIndex = 1;
            tb_port.Text = "11000";
            tb_port.TextAlign = HorizontalAlignment.Right;
            // 
            // lb_port
            // 
            lb_port.AutoSize = true;
            lb_port.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lb_port.Location = new Point(22, 46);
            lb_port.Margin = new Padding(2, 0, 2, 0);
            lb_port.Name = "lb_port";
            lb_port.Size = new Size(51, 25);
            lb_port.TabIndex = 2;
            lb_port.Text = "Port";
            // 
            // rb_log
            // 
            rb_log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rb_log.Location = new Point(8, 207);
            rb_log.Margin = new Padding(2);
            rb_log.Name = "rb_log";
            rb_log.Size = new Size(1061, 383);
            rb_log.TabIndex = 3;
            rb_log.Text = "";
            // 
            // b_connect
            // 
            b_connect.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            b_connect.Location = new Point(823, 20);
            b_connect.Margin = new Padding(2);
            b_connect.Name = "b_connect";
            b_connect.Size = new Size(214, 74);
            b_connect.TabIndex = 4;
            b_connect.Text = "Connect server";
            b_connect.UseVisualStyleBackColor = true;
            b_connect.Click += b_connect_Click;
            // 
            // tb_message
            // 
            tb_message.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tb_message.Location = new Point(552, 67);
            tb_message.Margin = new Padding(2);
            tb_message.Name = "tb_message";
            tb_message.Size = new Size(213, 32);
            tb_message.TabIndex = 5;
            tb_message.Text = "Hello TCP server!";
            // 
            // tb_server
            // 
            tb_server.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tb_server.Location = new Point(552, 20);
            tb_server.Margin = new Padding(2);
            tb_server.Name = "tb_server";
            tb_server.Size = new Size(213, 32);
            tb_server.TabIndex = 7;
            tb_server.Text = "92.53.99.68";
            // 
            // b_send
            // 
            b_send.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            b_send.Location = new Point(823, 111);
            b_send.Margin = new Padding(2);
            b_send.Name = "b_send";
            b_send.Size = new Size(214, 74);
            b_send.TabIndex = 8;
            b_send.Text = "Send Message";
            b_send.UseVisualStyleBackColor = true;
            b_send.Click += b_send_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 595);
            Controls.Add(b_send);
            Controls.Add(tb_server);
            Controls.Add(tb_message);
            Controls.Add(b_connect);
            Controls.Add(rb_log);
            Controls.Add(lb_port);
            Controls.Add(tb_port);
            Controls.Add(b_startserver);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button b_startserver;
        private TextBox tb_port;
        private Label lb_port;
        private RichTextBox rb_log;
        private Button b_connect;
        private TextBox tb_message;
        private TextBox tb_server;
        private Button b_send;
    }
}
