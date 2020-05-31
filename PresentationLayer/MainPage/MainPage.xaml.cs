using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace TinkoffCurrency
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            await SelectAndProcessFileAsync();
        }

        private async System.Threading.Tasks.Task SelectAndProcessFileAsync()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeFilter.Add(".xlsx");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                //file selected
                parseExcelDocument(file);
            }
            else
            {
                //operation cancelled
            }
        }

        private void parseExcelDocument(Windows.Storage.StorageFile file)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(file.Path, false))
            {
                // Code removed here.
            }
        }
    }
}
