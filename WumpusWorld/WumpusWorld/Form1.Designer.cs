﻿namespace WumpusWorld
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.btnArriba = new System.Windows.Forms.Button();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.btnAbajo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.sensor = new System.Windows.Forms.PictureBox();
            this.flechasGroup = new System.Windows.Forms.GroupBox();
            this.brisaDetector = new System.Windows.Forms.PictureBox();
            this.hedorDetector = new System.Windows.Forms.PictureBox();
            this.resplandorDetector = new System.Windows.Forms.PictureBox();
            this.luzDetector = new System.Windows.Forms.PictureBox();
            this.gritoDetector = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brisaDetector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hedorDetector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resplandorDetector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luzDetector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gritoDetector)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, -18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wumpus World";
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIzquierda.BackgroundImage")));
            this.btnIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIzquierda.Location = new System.Drawing.Point(674, 129);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(70, 70);
            this.btnIzquierda.TabIndex = 2;
            this.btnIzquierda.UseVisualStyleBackColor = true;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierda_Click);
            // 
            // btnArriba
            // 
            this.btnArriba.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnArriba.BackgroundImage")));
            this.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnArriba.Location = new System.Drawing.Point(742, 63);
            this.btnArriba.Name = "btnArriba";
            this.btnArriba.Size = new System.Drawing.Size(70, 70);
            this.btnArriba.TabIndex = 3;
            this.btnArriba.UseVisualStyleBackColor = true;
            this.btnArriba.Click += new System.EventHandler(this.btnArriba_Click);
            // 
            // btnDerecha
            // 
            this.btnDerecha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDerecha.BackgroundImage")));
            this.btnDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDerecha.Location = new System.Drawing.Point(809, 128);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(70, 70);
            this.btnDerecha.TabIndex = 4;
            this.btnDerecha.UseVisualStyleBackColor = true;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            // 
            // btnAbajo
            // 
            this.btnAbajo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbajo.BackgroundImage")));
            this.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbajo.Location = new System.Drawing.Point(742, 195);
            this.btnAbajo.Name = "btnAbajo";
            this.btnAbajo.Size = new System.Drawing.Size(70, 70);
            this.btnAbajo.TabIndex = 5;
            this.btnAbajo.UseVisualStyleBackColor = true;
            this.btnAbajo.Click += new System.EventHandler(this.btnAbajo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gritoDetector);
            this.groupBox1.Controls.Add(this.luzDetector);
            this.groupBox1.Controls.Add(this.resplandorDetector);
            this.groupBox1.Controls.Add(this.hedorDetector);
            this.groupBox1.Controls.Add(this.brisaDetector);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.sensor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1118, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 743);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensores";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(73, 559);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(141, 121);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(73, 420);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(141, 122);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(73, 286);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(141, 115);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(73, 161);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(141, 110);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // sensor
            // 
            this.sensor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sensor.BackgroundImage")));
            this.sensor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sensor.Location = new System.Drawing.Point(73, 44);
            this.sensor.Name = "sensor";
            this.sensor.Size = new System.Drawing.Size(141, 101);
            this.sensor.TabIndex = 0;
            this.sensor.TabStop = false;
            // 
            // flechasGroup
            // 
            this.flechasGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flechasGroup.Location = new System.Drawing.Point(708, 431);
            this.flechasGroup.Name = "flechasGroup";
            this.flechasGroup.Size = new System.Drawing.Size(404, 260);
            this.flechasGroup.TabIndex = 7;
            this.flechasGroup.TabStop = false;
            this.flechasGroup.Text = "Flechas";
            // 
            // brisaDetector
            // 
            this.brisaDetector.Location = new System.Drawing.Point(23, 82);
            this.brisaDetector.Name = "brisaDetector";
            this.brisaDetector.Size = new System.Drawing.Size(27, 27);
            this.brisaDetector.TabIndex = 5;
            this.brisaDetector.TabStop = false;
            // 
            // hedorDetector
            // 
            this.hedorDetector.Location = new System.Drawing.Point(23, 204);
            this.hedorDetector.Name = "hedorDetector";
            this.hedorDetector.Size = new System.Drawing.Size(27, 27);
            this.hedorDetector.TabIndex = 6;
            this.hedorDetector.TabStop = false;
            // 
            // resplandorDetector
            // 
            this.resplandorDetector.Location = new System.Drawing.Point(23, 333);
            this.resplandorDetector.Name = "resplandorDetector";
            this.resplandorDetector.Size = new System.Drawing.Size(27, 27);
            this.resplandorDetector.TabIndex = 8;
            this.resplandorDetector.TabStop = false;
            // 
            // luzDetector
            // 
            this.luzDetector.Location = new System.Drawing.Point(23, 470);
            this.luzDetector.Name = "luzDetector";
            this.luzDetector.Size = new System.Drawing.Size(27, 27);
            this.luzDetector.TabIndex = 8;
            this.luzDetector.TabStop = false;
            // 
            // gritoDetector
            // 
            this.gritoDetector.Location = new System.Drawing.Point(23, 609);
            this.gritoDetector.Name = "gritoDetector";
            this.gritoDetector.Size = new System.Drawing.Size(27, 27);
            this.gritoDetector.TabIndex = 8;
            this.gritoDetector.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.flechasGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAbajo);
            this.Controls.Add(this.btnDerecha);
            this.Controls.Add(this.btnArriba);
            this.Controls.Add(this.btnIzquierda);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brisaDetector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hedorDetector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resplandorDetector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luzDetector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gritoDetector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnArriba;
        private System.Windows.Forms.Button btnDerecha;
        private System.Windows.Forms.Button btnAbajo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox sensor;
        private System.Windows.Forms.GroupBox flechasGroup;
        private System.Windows.Forms.PictureBox gritoDetector;
        private System.Windows.Forms.PictureBox luzDetector;
        private System.Windows.Forms.PictureBox resplandorDetector;
        private System.Windows.Forms.PictureBox hedorDetector;
        private System.Windows.Forms.PictureBox brisaDetector;
    }
}

