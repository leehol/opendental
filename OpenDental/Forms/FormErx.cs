using System;
using System.IO;
using System.Windows.Forms;
using CodeBase;
using OpenDental.UI;
using OpenDentBusiness;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace OpenDental {
	///<summary>Internet browser window for NewCrop.  This is essentially a Microsoft Edge browser control embedded into our form.</summary>
	public partial class FormErx:FormODBase {
		///<summary>The PatNum of the patient eRx was opened for.  The patient is tied to the window so that when the window is closed the Chart
		///knows which patient to refresh.  If the patient is different than the patient modified in the eRx window then the Chart does not need to 
		///refresh.</summary>
		public Patient PatCur=null;
		///<summary>This XML contains the patient information, provider information, employee information, practice information, etc...</summary>
		public byte[] PostDataBytes=new byte[1];
		///<summary>Contains patient data used for the SSO already formatted as a query string.</summary>
		public string StringSSOQuery="";
		public ErxOption ErxOptionCur;
		///<summary>Default to false. Determines if url is single use or not. When this is set to true, then the refresh button is not added. See LayoutToolBar() 
		///Appriss's API returns a single use URL for PHI security reasons. Hitting refresh would cause an unauthorized message to show from their server which would force offices to close and relaunch the bridge.
		///</summary>
		public bool IsUrlSingleUse;
		///<summary>Disposed on form closing. There were instances of this stream being disposed before we were done using it so made it a class wide variable to force it to stay open.</summary>
		private MemoryStream _memoryStream;

		///<summary></summary>
		public FormErx() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private async void FormErx_Load(object sender,EventArgs e) {
			try {
				await webViewMain.Init();
			}
			catch(Exception ex) {
				ex.DoNothing();
				DialogResult=DialogResult.Cancel;
				Close();
			}
			Text=Lan.g(this,"Loading")+"...";
			LayoutToolBars();
			if(ErxOptionCur==ErxOption.Legacy) {
				ComposeNewRxLegacy();
			}
			else {
				ComposeNewRxDoseSpot();
			}
		}

		///<summary></summary>
		public void LayoutToolBars() {
			ToolBarMain.Buttons.Clear();
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Back"),0,"","Back"));
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Forward"),1,"","Forward"));
			if(!IsUrlSingleUse) {
				ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Refresh"),-1,"","Refresh"));
			}
			ToolBarMain.Buttons.Add(new ODToolBarButton(Lan.g(this,"Close"),-1,"","Close"));
			ToolBarMain.Invalidate();
		}

		///<summary>Sends the ClickThroughXml to eRx and loads the result within the browser control.
		///Loads the compose tab in NewCrop's web interface.  Can be called externally to send provider information to eRx
		///without allowing the user to write any prescriptions.</summary>
		public void ComposeNewRxLegacy() {
			string additionalHeaders="Content-Type: application/x-www-form-urlencoded\r\n";
			string newCropUrl=Erx.GetLegacyUrl();
			_memoryStream?.Dispose();
			_memoryStream=new MemoryStream(PostDataBytes);
			CoreWebView2WebResourceRequest coreWebView2WebResourceRequest=webViewMain.CoreWebView2.Environment.CreateWebResourceRequest(newCropUrl,"POST",_memoryStream,additionalHeaders);
			webViewMain.CoreWebView2.NavigateWithWebResourceRequest(coreWebView2WebResourceRequest);
		}

		public void ComposeNewRxDoseSpot() {
			string doseSpotUrl=Erx.GetRxDoseSpotUrl(StringSSOQuery);
			webViewMain.CoreWebView2.Navigate(doseSpotUrl);
		}

		private void webViewMain_NavigationCompleted(object sender,CoreWebView2NavigationCompletedEventArgs e) {
			SetTitle();
		}

		private void ToolBarMain_ButtonClick(object sender,ODToolBarButtonClickEventArgs e) {
			switch(e.Button.Tag.ToString()) {
				case "Back":
					if(webViewMain.CanGoBack) {
						Cursor=Cursors.WaitCursor;//Is set back to default cursor after the document loads inside the browser.
						Application.DoEvents();//To show cursor change.
						Text=Lan.g(this,"Loading")+"...";
						webViewMain.GoBack();
					}
					break;
				case "Forward":
					if(webViewMain.CanGoForward) {
						Cursor=Cursors.WaitCursor;//Is set back to default cursor after the document loads inside the browser.
						Application.DoEvents();//To show cursor change.
						Text=Lan.g(this,"Loading")+"...";
						webViewMain.GoForward();
					}
					break;
				case "Refresh":
					webViewMain.Refresh();
					break;
				case "Close":
					DialogResult=DialogResult.Cancel;
					Close();//For when we launch the window in a non-modal manner.
					break;
			}
		}

		private void SetTitle() {
			Text=Lan.g(this,"eRx");
			if(webViewMain.CoreWebView2!=null && !string.IsNullOrWhiteSpace(webViewMain.CoreWebView2.DocumentTitle)) {
				Text+=" - "+webViewMain.CoreWebView2.DocumentTitle;
			}
			if(PatCur!=null) {//Can only be null when a subwindow is opened by clicking on a link from inside another FormErx instance.
				Text+=" - "+PatCur.GetNameFL();
			}
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			ODEvent.Fire(ODEventType.ErxBrowserClosed,PatCur);
		}
	}
}