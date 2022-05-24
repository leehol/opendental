﻿
namespace OpenDental {
	partial class UserControlFamilyInsurance {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
		if(disposing && (components != null)) {
		components.Dispose();
		}
		base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.checkInsurancePlansShared = new System.Windows.Forms.CheckBox();
			this.checkCoPayFeeScheduleBlankLikeZero = new System.Windows.Forms.CheckBox();
			this.checkInsDefaultShowUCRonClaims = new System.Windows.Forms.CheckBox();
			this.checkInsPPOsecWriteoffs = new System.Windows.Forms.CheckBox();
			this.checkInsDefaultAssignmentOfBenefits = new System.Windows.Forms.CheckBox();
			this.checkClaimUseOverrideProcDescript = new System.Windows.Forms.CheckBox();
			this.checkInsPlanExclusionsUseUCR = new System.Windows.Forms.CheckBox();
			this.checkPPOpercentage = new System.Windows.Forms.CheckBox();
			this.checkInsPlanExclusionsMarkDoNotBill = new System.Windows.Forms.CheckBox();
			this.checkClaimTrackingRequireError = new System.Windows.Forms.CheckBox();
			this.checkFixedBenefitBlankLikeZero = new System.Windows.Forms.CheckBox();
			this.groupBoxInsuranceGeneral = new OpenDental.UI.GroupBoxOD();
			this.checkPatInitBillingTypeFromPriInsPlan = new System.Windows.Forms.CheckBox();
			this.groupBoxOtherInsInfo = new OpenDental.UI.GroupBoxOD();
			this.groupBoxClaims = new OpenDental.UI.GroupBoxOD();
			this.groupBoxInsuranceGeneral.SuspendLayout();
			this.groupBoxOtherInsInfo.SuspendLayout();
			this.groupBoxClaims.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkInsurancePlansShared
			// 
			this.checkInsurancePlansShared.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkInsurancePlansShared.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsurancePlansShared.Location = new System.Drawing.Point(40, 15);
			this.checkInsurancePlansShared.Name = "checkInsurancePlansShared";
			this.checkInsurancePlansShared.Size = new System.Drawing.Size(400, 17);
			this.checkInsurancePlansShared.TabIndex = 257;
			this.checkInsurancePlansShared.Text = "InsPlan option at bottom, \'Change Plan for all subscribers\', is default";
			this.checkInsurancePlansShared.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkCoPayFeeScheduleBlankLikeZero
			// 
			this.checkCoPayFeeScheduleBlankLikeZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkCoPayFeeScheduleBlankLikeZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkCoPayFeeScheduleBlankLikeZero.Location = new System.Drawing.Point(40, 61);
			this.checkCoPayFeeScheduleBlankLikeZero.Name = "checkCoPayFeeScheduleBlankLikeZero";
			this.checkCoPayFeeScheduleBlankLikeZero.Size = new System.Drawing.Size(400, 17);
			this.checkCoPayFeeScheduleBlankLikeZero.TabIndex = 260;
			this.checkCoPayFeeScheduleBlankLikeZero.Text = "Copay fee schedules treat blank entries as zero";
			this.checkCoPayFeeScheduleBlankLikeZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkInsDefaultShowUCRonClaims
			// 
			this.checkInsDefaultShowUCRonClaims.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkInsDefaultShowUCRonClaims.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsDefaultShowUCRonClaims.Location = new System.Drawing.Point(40, 15);
			this.checkInsDefaultShowUCRonClaims.Name = "checkInsDefaultShowUCRonClaims";
			this.checkInsDefaultShowUCRonClaims.Size = new System.Drawing.Size(400, 17);
			this.checkInsDefaultShowUCRonClaims.TabIndex = 261;
			this.checkInsDefaultShowUCRonClaims.Text = "Insurance plans default to show UCR fee on claims";
			this.checkInsDefaultShowUCRonClaims.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsDefaultShowUCRonClaims.Click += new System.EventHandler(this.checkInsDefaultShowUCRonClaims_Click);
			// 
			// checkInsPPOsecWriteoffs
			// 
			this.checkInsPPOsecWriteoffs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkInsPPOsecWriteoffs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsPPOsecWriteoffs.Location = new System.Drawing.Point(15, 130);
			this.checkInsPPOsecWriteoffs.Name = "checkInsPPOsecWriteoffs";
			this.checkInsPPOsecWriteoffs.Size = new System.Drawing.Size(425, 17);
			this.checkInsPPOsecWriteoffs.TabIndex = 270;
			this.checkInsPPOsecWriteoffs.Text = "Calculate secondary insurance PPO write-offs (not recommended, see manual)";
			this.checkInsPPOsecWriteoffs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsPPOsecWriteoffs.UseVisualStyleBackColor = true;
			// 
			// checkInsDefaultAssignmentOfBenefits
			// 
			this.checkInsDefaultAssignmentOfBenefits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkInsDefaultAssignmentOfBenefits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsDefaultAssignmentOfBenefits.Location = new System.Drawing.Point(40, 107);
			this.checkInsDefaultAssignmentOfBenefits.Name = "checkInsDefaultAssignmentOfBenefits";
			this.checkInsDefaultAssignmentOfBenefits.Size = new System.Drawing.Size(400, 17);
			this.checkInsDefaultAssignmentOfBenefits.TabIndex = 267;
			this.checkInsDefaultAssignmentOfBenefits.Text = "Insurance plans default to assignment of benefits";
			this.checkInsDefaultAssignmentOfBenefits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsDefaultAssignmentOfBenefits.Click += new System.EventHandler(this.checkInsDefaultAssignmentOfBenefits_Click);
			// 
			// checkClaimUseOverrideProcDescript
			// 
			this.checkClaimUseOverrideProcDescript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkClaimUseOverrideProcDescript.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkClaimUseOverrideProcDescript.Location = new System.Drawing.Point(40, 15);
			this.checkClaimUseOverrideProcDescript.Name = "checkClaimUseOverrideProcDescript";
			this.checkClaimUseOverrideProcDescript.Size = new System.Drawing.Size(400, 17);
			this.checkClaimUseOverrideProcDescript.TabIndex = 263;
			this.checkClaimUseOverrideProcDescript.Text = "Use the description for the charted procedure code on printed claims";
			this.checkClaimUseOverrideProcDescript.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkInsPlanExclusionsUseUCR
			// 
			this.checkInsPlanExclusionsUseUCR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkInsPlanExclusionsUseUCR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsPlanExclusionsUseUCR.Location = new System.Drawing.Point(18, 38);
			this.checkInsPlanExclusionsUseUCR.Name = "checkInsPlanExclusionsUseUCR";
			this.checkInsPlanExclusionsUseUCR.Size = new System.Drawing.Size(422, 17);
			this.checkInsPlanExclusionsUseUCR.TabIndex = 277;
			this.checkInsPlanExclusionsUseUCR.Text = "Ins plans with exclusions use UCR fee (can be overridden by plan)";
			this.checkInsPlanExclusionsUseUCR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkPPOpercentage
			// 
			this.checkPPOpercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkPPOpercentage.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkPPOpercentage.Location = new System.Drawing.Point(40, 38);
			this.checkPPOpercentage.Name = "checkPPOpercentage";
			this.checkPPOpercentage.Size = new System.Drawing.Size(400, 17);
			this.checkPPOpercentage.TabIndex = 258;
			this.checkPPOpercentage.Text = "Default new insurance plans to PPO Percentage plan type";
			this.checkPPOpercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkInsPlanExclusionsMarkDoNotBill
			// 
			this.checkInsPlanExclusionsMarkDoNotBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkInsPlanExclusionsMarkDoNotBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkInsPlanExclusionsMarkDoNotBill.Location = new System.Drawing.Point(18, 61);
			this.checkInsPlanExclusionsMarkDoNotBill.Name = "checkInsPlanExclusionsMarkDoNotBill";
			this.checkInsPlanExclusionsMarkDoNotBill.Size = new System.Drawing.Size(422, 17);
			this.checkInsPlanExclusionsMarkDoNotBill.TabIndex = 276;
			this.checkInsPlanExclusionsMarkDoNotBill.Text = "Ins plans with exclusions mark as Do Not Bill Ins";
			this.checkInsPlanExclusionsMarkDoNotBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkClaimTrackingRequireError
			// 
			this.checkClaimTrackingRequireError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkClaimTrackingRequireError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkClaimTrackingRequireError.Location = new System.Drawing.Point(15, 38);
			this.checkClaimTrackingRequireError.Name = "checkClaimTrackingRequireError";
			this.checkClaimTrackingRequireError.Size = new System.Drawing.Size(425, 17);
			this.checkClaimTrackingRequireError.TabIndex = 266;
			this.checkClaimTrackingRequireError.Text = "Require error code when adding claim custom tracking status";
			this.checkClaimTrackingRequireError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkFixedBenefitBlankLikeZero
			// 
			this.checkFixedBenefitBlankLikeZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkFixedBenefitBlankLikeZero.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkFixedBenefitBlankLikeZero.Location = new System.Drawing.Point(40, 84);
			this.checkFixedBenefitBlankLikeZero.Name = "checkFixedBenefitBlankLikeZero";
			this.checkFixedBenefitBlankLikeZero.Size = new System.Drawing.Size(400, 17);
			this.checkFixedBenefitBlankLikeZero.TabIndex = 275;
			this.checkFixedBenefitBlankLikeZero.Text = "Fixed benefit fee schedules treat blank entries as zero";
			this.checkFixedBenefitBlankLikeZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBoxInsuranceGeneral
			// 
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkPatInitBillingTypeFromPriInsPlan);
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkInsurancePlansShared);
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkFixedBenefitBlankLikeZero);
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkCoPayFeeScheduleBlankLikeZero);
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkInsPPOsecWriteoffs);
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkPPOpercentage);
			this.groupBoxInsuranceGeneral.Controls.Add(this.checkInsDefaultAssignmentOfBenefits);
			this.groupBoxInsuranceGeneral.Location = new System.Drawing.Point(20, 40);
			this.groupBoxInsuranceGeneral.Name = "groupBoxInsuranceGeneral";
			this.groupBoxInsuranceGeneral.Size = new System.Drawing.Size(450, 180);
			this.groupBoxInsuranceGeneral.TabIndex = 278;
			this.groupBoxInsuranceGeneral.Text = "Insurance General";
			// 
			// checkPatInitBillingTypeFromPriInsPlan
			// 
			this.checkPatInitBillingTypeFromPriInsPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkPatInitBillingTypeFromPriInsPlan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkPatInitBillingTypeFromPriInsPlan.Location = new System.Drawing.Point(40, 153);
			this.checkPatInitBillingTypeFromPriInsPlan.Name = "checkPatInitBillingTypeFromPriInsPlan";
			this.checkPatInitBillingTypeFromPriInsPlan.Size = new System.Drawing.Size(400, 17);
			this.checkPatInitBillingTypeFromPriInsPlan.TabIndex = 298;
			this.checkPatInitBillingTypeFromPriInsPlan.Text = "New patient primary insurance plan sets patient billing type";
			this.checkPatInitBillingTypeFromPriInsPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBoxOtherInsInfo
			// 
			this.groupBoxOtherInsInfo.Controls.Add(this.checkInsDefaultShowUCRonClaims);
			this.groupBoxOtherInsInfo.Controls.Add(this.checkInsPlanExclusionsUseUCR);
			this.groupBoxOtherInsInfo.Controls.Add(this.checkInsPlanExclusionsMarkDoNotBill);
			this.groupBoxOtherInsInfo.Location = new System.Drawing.Point(20, 234);
			this.groupBoxOtherInsInfo.Name = "groupBoxOtherInsInfo";
			this.groupBoxOtherInsInfo.Size = new System.Drawing.Size(450, 88);
			this.groupBoxOtherInsInfo.TabIndex = 279;
			this.groupBoxOtherInsInfo.Text = "Other Insurance Info";
			// 
			// groupBoxClaims
			// 
			this.groupBoxClaims.Controls.Add(this.checkClaimUseOverrideProcDescript);
			this.groupBoxClaims.Controls.Add(this.checkClaimTrackingRequireError);
			this.groupBoxClaims.Location = new System.Drawing.Point(20, 336);
			this.groupBoxClaims.Name = "groupBoxClaims";
			this.groupBoxClaims.Size = new System.Drawing.Size(450, 65);
			this.groupBoxClaims.TabIndex = 280;
			this.groupBoxClaims.Text = "Claims";
			// 
			// UserControlFamilyInsurance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.groupBoxClaims);
			this.Controls.Add(this.groupBoxOtherInsInfo);
			this.Controls.Add(this.groupBoxInsuranceGeneral);
			this.Name = "UserControlFamilyInsurance";
			this.Size = new System.Drawing.Size(974, 641);
			this.groupBoxInsuranceGeneral.ResumeLayout(false);
			this.groupBoxOtherInsInfo.ResumeLayout(false);
			this.groupBoxClaims.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.CheckBox checkInsurancePlansShared;
		private System.Windows.Forms.CheckBox checkCoPayFeeScheduleBlankLikeZero;
		private System.Windows.Forms.CheckBox checkInsDefaultShowUCRonClaims;
		private System.Windows.Forms.CheckBox checkInsPPOsecWriteoffs;
		private System.Windows.Forms.CheckBox checkInsDefaultAssignmentOfBenefits;
		private System.Windows.Forms.CheckBox checkClaimUseOverrideProcDescript;
		private System.Windows.Forms.CheckBox checkInsPlanExclusionsUseUCR;
		private System.Windows.Forms.CheckBox checkPPOpercentage;
		private System.Windows.Forms.CheckBox checkInsPlanExclusionsMarkDoNotBill;
		private System.Windows.Forms.CheckBox checkClaimTrackingRequireError;
		private System.Windows.Forms.CheckBox checkFixedBenefitBlankLikeZero;
		private UI.GroupBoxOD groupBoxInsuranceGeneral;
		private System.Windows.Forms.CheckBox checkPatInitBillingTypeFromPriInsPlan;
		private UI.GroupBoxOD groupBoxOtherInsInfo;
		private UI.GroupBoxOD groupBoxClaims;
	}
}