using CodeBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormEServicesSetup:FormODBase {
		private const int CP_NOCLOSE_BUTTON = 0x200;
		///<summary>Output from HQ initialized in FillForm().</summary>
		WebServiceMainHQProxy.EServiceSetup.SignupOut _signupOut;

		public FormEServicesSetup() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormEServicesSetup_Load(object sender,EventArgs e) {
			try {
				_signupOut=GetSignupOut();
				if(_signupOut is null){
					DialogResult=DialogResult.Abort;
					Close();
				}
			}
			catch(WebException we) {
				FriendlyException.Show(Lan.g(this,"Could not reach HQ.  Please make sure you have an internet connection and try again or call support."),we);
				//Set the dialog result to Abort so that FormClosing knows to not try and save any changes.
				DialogResult=DialogResult.Abort;
				Close();
			}
			catch(Exception ex) {
				FriendlyException.Show(Lan.g(this,"There was a problem loading the eServices Setup window.  Please try again or call support."),ex);
				//Set the dialog result to Abort so that FormClosing knows to not try and save any changes.
				DialogResult=DialogResult.Abort;
				Close();
			}
			butSecureEmail.Visible=EmailSecures.IsSecureEmailReleased();
		}

		/// <summary>When the user is trying to send a text message, if sending the text would exceed the users spending limit, this handles that error.
		/// If the user has permission to increase the spending limit, open a new FormEservicesSetup to allow them to increase their spending limit,
		/// otherwise warn them that they do not have permission. Returns true if the error passed in matches the spending limit error, false otherwise. </summary>
		public static bool ProcessSendSmsException(Exception ex) {
			if((ex is ODException) && ((ODException)ex).ErrorCode==1) {
				if(MsgBox.Show(typeof(FormEServicesSetup),MsgBoxButtons.YesNo,ex.Message+" Do you want to increase this spending limit?")) {
					if(Security.IsAuthorized(Permissions.EServicesSetup)) {
						FormEServicesSetup FormESSetup=new FormEServicesSetup();
						FormESSetup.Show();
					}
				}
				return true;
			}
			return false;
		}

		///<summary>Makes a web call to WebServiceMainHQ to get the corresponding EServiceSetupFull information and then attempts to fill each tab.
		///If anything goes wrong within this method a message box will show to the user and then the window will auto close via Abort.</summary>
		public static WebServiceMainHQProxy.EServiceSetup.SignupOut GetSignupOut(WebServiceMainHQProxy.EServiceSetup.SignupOut signupOut=null) {
			if(!ODBuild.IsWeb() && MiscUtils.TryUpdateIeEmulation()) {
				throw new Exception("Browser emulation version updated.\r\nYou must restart this application before accessing the Signup Portal.");
			}
			//Send light version of clinics to HQ to be used by signup portal below. Get back all args needed from HQ in order to perform the operations of this window.
			SignupPortalPermission signalPortalPerm=GetUserSignupPortalPermissions();
			SecurityLogs.MakeLogEntry(Permissions.Setup,0,$"User {Security.CurUser.UserName} entered EService Setup with SignupPortalPermission {signalPortalPerm}");
			UI.ProgressOD progressOD=new UI.ProgressOD();
			progressOD.ShowCancelButton=false; // approved by Jordan to hide cancel button here. 
			if(signupOut==null) { //the first time this loads signupOut will be null, so we won't have a previous state to compare
				progressOD.ActionMain=() => signupOut=WebServiceMainHQProxy.GetEServiceSetupFull(signalPortalPerm);
			}
			else { //If we are switching from the signup tab to another this will get called again and we don't want to lose the "diff"
				progressOD.ActionMain=() => signupOut=WebServiceMainHQProxy.GetEServiceSetupFull(signalPortalPerm,oldSignupOut:signupOut);
			}
			progressOD.StartingMessage="Validating eServices...";
			progressOD.ShowDialogProgress();
			if(progressOD.IsCancelled){
				return null;
			}
			//Show user any prompts that were generated by GetEServiceSetupFull().
			if(signupOut.Prompts.Count>0) {
				MessageBox.Show(string.Join("\r\n",signupOut.Prompts));//.Select(x => Lans.g(this,x))));
			}
			return signupOut;
		}

		private static SignupPortalPermission GetUserSignupPortalPermissions() {
			SignupPortalPermission signalPortalPerm=SignupPortalPermission.ReadOnly;
			if(Security.IsAuthorized(Permissions.SecurityAdmin,true)) {
				signalPortalPerm=SignupPortalPermission.FullPermission;
			}
			else if(Security.IsAuthorized(Permissions.EServicesSetup,true)) {
				signalPortalPerm=SignupPortalPermission.ReadOnly;
			}
			else {
				signalPortalPerm=SignupPortalPermission.Denied;
			}
			return signalPortalPerm;
		}

		private void butSignup_Click(object sender,EventArgs e) {
			using FormEServicesSignup formESSignup2=new FormEServicesSignup(_signupOut);
			formESSignup2.ShowDialog();
			//Signups may have changed so re-sync here before allowing other setups to occur.
			_signupOut=GetSignupOut(_signupOut);
			butSecureEmail.Visible=EmailSecures.IsSecureEmailReleased();
		}

		private void butEConnector_Click(object sender,EventArgs e) {
			using FormEServicesEConnector formESEConnector=new FormEServicesEConnector();
			formESEConnector.ShowDialog();
		}

		private void butMobileWeb_Click(object sender,EventArgs e) {
			using FormEServicesMobileWeb formESMobileWeb=new FormEServicesMobileWeb(_signupOut);
			formESMobileWeb.ShowDialog();
		}

		private void butPatPortal_Click(object sender,EventArgs e) {
			using FormEServicesPatientPortal formESPatPortal=new FormEServicesPatientPortal(_signupOut);
			formESPatPortal.ShowDialog();
		}

		private void butSMSTemplateSetup_Click(object sender,EventArgs e) {
			using FormTextPaySetup formTextPaySetup=new FormTextPaySetup();
			formTextPaySetup.ShowDialog();
		}

		private void butTextingServices_Click(object sender,EventArgs e) {
			using FormEServicesTexting formESTexting=new FormEServicesTexting(_signupOut);
			formESTexting.ShowDialog();
		}

		private void butECR_Click(object sender,EventArgs e) {
			using FormEServicesAutoMsging formESAutoMsging=new FormEServicesAutoMsging(_signupOut);
			formESAutoMsging.ShowDialog();
		}

		private void butEClipboard_Click(object sender,EventArgs e) {
			using FormEServicesEClipboard formESEClipboard=new FormEServicesEClipboard();
			formESEClipboard.ShowDialog();
		}

		private void butMisc_Click(object sender,EventArgs e) {
			using FormEServicesMisc formESMisc=new FormEServicesMisc(_signupOut);
			formESMisc.ShowDialog();
		}

		private void butMassEmail_Click(object sender,EventArgs e) {
			using FormMassEmailSetup formESMassEmail=new FormMassEmailSetup(_signupOut);
			formESMassEmail.ShowDialog();
		}

		private void butSecureEmail_Click(object sender,EventArgs e) {
			using FormSecureEmailSetup formSecureEmail=new FormSecureEmailSetup(_signupOut);
			formSecureEmail.ShowDialog();
		}

		private void butMobileSettings_Click(object sender,EventArgs e) {
			using FormEServicesMobileSettings formEServicesMobileSettings=new FormEServicesMobileSettings();
			formEServicesMobileSettings.ShowDialog();
		}

		private void butMobileSync_Click(object sender,EventArgs e) {
			using FormEServicesMobileSynch formESMobileSync=new FormEServicesMobileSynch();
			formESMobileSync.ShowDialog();
		}

		#region WebScheduling
		private void butRecall_Click(object sender,EventArgs e) {
			using FormEServicesWebSchedRecall formESWebSchedRecall=new FormEServicesWebSchedRecall();
			formESWebSchedRecall.ShowDialog();
		}

		private void butNewPatient_Click(object sender,EventArgs e) {
			using FormEServicesWebSchedPat formEServicesWebSchedPat=new FormEServicesWebSchedPat(true);
			formEServicesWebSchedPat.SignupOut=_signupOut;
			formEServicesWebSchedPat.ShowDialog();
		}

		private void butExistingPatient_Click(object sender,EventArgs e) {
			using FormEServicesWebSchedPat formEServicesWebSchedPat=new FormEServicesWebSchedPat();
			formEServicesWebSchedPat.SignupOut=_signupOut;
			formEServicesWebSchedPat.ShowDialog();
		}

		private void butAdvanced_Click(object sender,EventArgs e) {
			using FormEServicesWebSchedAdvanced formEServicesWebSchedAdvanced=new FormEServicesWebSchedAdvanced(_signupOut);
			formEServicesWebSchedAdvanced.ShowDialog();
		}
		#endregion

		private void butClose_Click(object sender,EventArgs e) {
			Close();
		}

		private void FormEServicesSetup2_FormClosing(object sender,FormClosingEventArgs e) {
			if(DialogResult==DialogResult.Abort || !Security.IsAuthorized(Permissions.EServicesSetup,true)) {
				return;
			}
			DataValid.SetInvalid(InvalidType.Prefs);
			DataValid.SetInvalid(InvalidType.Providers);//Providers includes clinics.
			//Call this a second time so we can log if any important changes were made to this form.
			//_signupOut gets filled on load and should not be null at this point
			UI.ProgressOD progressOD=new UI.ProgressOD();
			progressOD.ActionMain=() =>WebServiceMainHQProxy.GetEServiceSetupFull(GetUserSignupPortalPermissions(),oldSignupOut:_signupOut);
			progressOD.StartingMessage="Saving eServices...";
			progressOD.ShowDialogProgress();
		}
	}
}