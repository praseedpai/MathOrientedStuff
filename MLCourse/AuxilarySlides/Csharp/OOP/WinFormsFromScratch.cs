////////////////////////////////
// test.cs
// A simple C# program which can be compiled
// using Mono on Linux , MAC OS X and Windows
//
// mcs test.cs /r:System.Windows.Forms.dll
//             /r:System.Drawing.dll
// mono test.exe on GNU Linux
// test.exe on Windows
// 
//
using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
/////////////////////////////////////////
//
// Every Desktop application has got a MainForm
// which is derived from System.Windows.Forms.Form
//
//
//
public class MainForm : Form {
    
    private Label lblOne;
    private Label lblTwo;
    private Button BtnOne;
    private TextBox TextOne;
    private TextBox TextTwo;

   ///////////////////////////////////////
   //
   // The constructor just sets the title ....
   //
   MainForm():base() {

       /////////////////////////
       //
       // Create all the controls
       //
       //

       lblOne = new Label();
       lblTwo = new Label();
       BtnOne = new Button();
       TextOne = new TextBox();
       TextTwo = new TextBox();
       
       /////////////////////
       // Do not mess with the Layout
       // While we are chaning layout
       //
       this.SuspendLayout();

       //////////////////////
       //
       // Set the Title
       //
       //
       this.Text ="Cross Platform Mono code...";

       //////////////////////////
       // Set the Two Label ( Prompt)
       // Parameters
       //
       lblOne.Location = new System.Drawing.Point(67, 47);
       lblOne.Name = "lblOne";
       lblOne.Size = new System.Drawing.Size(42, 13);
       lblOne.TabIndex = 0;
       lblOne.Text = "Enter A";

       lblTwo.Location = new System.Drawing.Point(67, 101);
       lblTwo.Name = "lblOne";
       lblTwo.Size = new System.Drawing.Size(42, 13);
       lblTwo.TabIndex = 2;
       lblTwo.Text = "Enter B";

       //////////////////////////////////////
       // Set the Text Box Params
       //
       //
       TextOne.Location = new System.Drawing.Point(180, 40);
       TextOne.Name = "textBox1";
       TextOne.Size = new System.Drawing.Size(100, 20);
       TextOne.TabIndex = 1;
       
       TextTwo.Location = new System.Drawing.Point(180, 94);
       TextTwo.Name = "textBox2";
       TextTwo.Size = new System.Drawing.Size(100, 20);
       TextTwo.TabIndex = 3;
       ///////////////////////
       // Set the Button Parameters
       //
       BtnOne.Location = new System.Drawing.Point(140, 157);
       BtnOne.Name = "BtnOne";
       BtnOne.Size = new System.Drawing.Size(75, 23);
       BtnOne.TabIndex = 4;
       BtnOne.Text = "Add ";
       BtnOne.Click += new System.EventHandler(BtnOneClick);

       ///////////////////////////////////
       //
       // Set the Client Window Size
       //
       this.ClientSize = new System.Drawing.Size(361, 262);

       ///////////////////////////////////
       //
       // Add all the Controls
       //
       this.Controls.Add(TextOne);
       this.Controls.Add(TextTwo);
       this.Controls.Add(lblOne);
       this.Controls.Add(lblTwo);
       this.Controls.Add(BtnOne);
       this.ResumeLayout(false);
       this.PerformLayout();
   }


   //////////////////////////////////////
   //
   // Event Handler
   //   Retrieve the Text and Convert to 
   //   double using TryParse.
   //
   private void BtnOneClick(object sender, EventArgs e)
   {
        String sa = TextOne.Text; 
        String sb = TextTwo.Text;

        double da;
        double db;
        if (Double.TryParse(sa,out da) &&
                Double.TryParse(sb,out db) )
        {

                double c = da + db;
                MessageBox.Show("result is " + c.ToString());
         }
         else
         {
                MessageBox.Show("Invalid Parameters");
         }
   }
   ///////////////////////////////
   //
   // The Entrypoint ...
   //
   //
   public static void Main(String [] args ) {
       MainForm mf = new MainForm();
       Application.Run(mf);
   }
}