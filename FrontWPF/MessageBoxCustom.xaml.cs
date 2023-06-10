using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MessageBoxCustom.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        public MessageBoxCustom(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {
                case MessageType.Info:
                    txtTitle.Text = "Info";
                    txtTitle.Foreground = Brushes.Black;
                    borderTitle.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#0dcaf0");
                    break;
                case MessageType.Confirmation:
                    
                    borderTitle.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#5c636a");
                    txtTitle.Text = "Confirmation";
                    break;
                case MessageType.Success:
                    {
                        txtTitle.Text = "Success";
                        borderTitle.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#157347");
                    }
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Warning";
                    txtTitle.Foreground = Brushes.Black;
                    borderTitle.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#ffc107");

                    break;
                case MessageType.Error:
                    {
                        borderTitle.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#dc3545");
                        txtTitle.Text = "Error";
                    }
                    break;
            }

            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    btnWarning.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    btnWarning.Visibility = Visibility.Collapsed;
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnWarning.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Warning:
                    btnWarning.Visibility = Visibility.Visible;
                    btnOk.Visibility = Visibility.Collapsed;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; 
                    btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        private void btnWarning_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
    public enum MessageType
    {
        Info,
        Confirmation,
        Success,
        Warning,
        Error,
    }
    public enum MessageButtons
    {
        OkCancel,
        Warning,
        YesNo,
        Ok,
    }

}
