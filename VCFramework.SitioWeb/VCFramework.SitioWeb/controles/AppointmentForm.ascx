<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppointmentForm.ascx.cs" Inherits="VCFramework.SitioWeb.controles.AppointmentForm" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxwschsc" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div runat="server" id="ValidationContainer" class="row">
    <div class="row">
        <div class="name-field medium-6 columns">
            <dx:ASPxLabel ID="lblSubject" runat="server" AssociatedControlID="tbSubject">
                
            </dx:ASPxLabel>
            <dx:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" Text='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Subject %>' >
                <ValidationSettings Display="None">
                    <RequiredField ErrorText="Asunto Requerido" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxTextBox>
        </div>
        <div class="name-field medium-6 columns">
            <dx:ASPxLabel ID="lblLocation" runat="server" AssociatedControlID="tbLocation">
            </dx:ASPxLabel>
             <dx:ASPxTextBox ClientInstanceName="_dx" ID="tbLocation" runat="server" Width="100%" Text='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Appointment.Location %>' >
                 <ValidationSettings Display="None">
                     <RequiredField ErrorText="Ubicación Requerida" IsRequired="True" />
                 </ValidationSettings>
            </dx:ASPxTextBox>
        </div>
    </div>
    <div class="row">
        <div class="name-field medium-2 columns">
            <dx:ASPxLabel ID="lblLabel" runat="server" AssociatedControlID="edtLabel">
            </dx:ASPxLabel>
            <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" ValueType="System.Int32" DataSource='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).LabelDataSource %>' >
                <ValidationSettings Display="None">
                    <RequiredField ErrorText="Etiqueta Requerida" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxComboBox>

        </div>
        <div class="name-field medium-5 columns">
            <dx:ASPxLabel ID="lblStartDate" runat="server" AssociatedControlID="edtStartDate" Wrap="false">
                        </dx:ASPxLabel>
            <div class="medium-8 columns">
            <dx:ASPxDateEdit ID="edtStartDate" runat="server" Width="100%" Date='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Start %>' EditFormat="Date" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" >
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
            </dx:ASPxDateEdit>
                </div>
            <div class="medium-4 columns">
                <dx:ASPxTimeEdit ID="edtStartTime" runat="server" Width="100%" DateTime='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Start %>' DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" >
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxTimeEdit>

            </div>

        </div>
        <div class="name-field medium-5 columns">

            <dx:ASPxLabel runat="server" ID="lblEndDate" Wrap="false" AssociatedControlID="edtEndDate"/>
            <div class="medium-8 columns">
                <dx:ASPxDateEdit id="edtEndDate" runat="server" Date='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).End %>' EditFormat="Date" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
            </div>
            <div class="medium-4 columns">
                <dx:ASPxTimeEdit ID="edtEndTime" runat="server" Width="100%" DateTime='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).End %>' DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" HelpTextSettings-PopupMargins-MarginLeft="50">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxTimeEdit>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="name-field medium-6 columns">
            <dx:ASPxLabel ID="lblStatus" runat="server" AssociatedControlID="edtStatus" Wrap="false">
                        </dx:ASPxLabel>
            <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" ValueType="System.Int32" DataSource='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).StatusDataSource %>' />
        </div>
        <div class="name-field medium-6 columns">
            <div class="small-2 columns padding-10">
            <dx:ASPxCheckBox ClientInstanceName="_dx" ID="chkAllDay" runat="server" Checked='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Appointment.AllDay %>'>
                        </dx:ASPxCheckBox>

            </div>
            <div class="small-10 columns padding-10">
                <dx:ASPxLabel ID="lblAllDay" runat="server" AssociatedControlID="chkAllDay" Font-Bold="true" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="name-field medium-12 columns">
            <label>
                Descripción
        <dx:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" runat="server" Width="100%" Rows="6" Text='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Appointment.Description %>' >
            <%--<ValidationSettings Display="None">
                    <RequiredField ErrorText="Etiqueta Descripción requerida" IsRequired="True" />
                </ValidationSettings>--%>
            </dx:ASPxMemo>
            </label>
        </div>
    </div>

    <dxwschsc:AppointmentRecurrenceForm ID="AppointmentRecurrenceForm1" runat="server"
        IsRecurring='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).Appointment.IsRecurring %>' 
    DayNumber='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceDayNumber %>' 
    End='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceEnd %>' 
    Month='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceMonth %>' 
    OccurrenceCount='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceOccurrenceCount %>' 
    Periodicity='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrencePeriodicity %>' 
    RecurrenceRange='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceRange %>' 
    Start='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceStart %>' 
    WeekDays='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceWeekDays %>' 
    WeekOfMonth='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceWeekOfMonth %>' 
    RecurrenceType='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).RecurrenceType %>'
    IsFormRecreated='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).IsFormRecreated %>' >

    </dxwschsc:AppointmentRecurrenceForm>
    <hr />
    <div class="row">
        <dx:ASPxValidationSummary ID="ASPxValidationSummary1" runat="server"></dx:ASPxValidationSummary>
    </div>
    <div class="row">
        <div class="name-field medium-4 columns">
            <dx:ASPxButton runat="server" ID="btnOk" UseSubmitBehavior="false" AutoPostBack="false" 
                            EnableViewState="false" Width="91px" EnableClientSideAPI="true" Native="true" CssClass="button" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem;font-size: 1rem;background-color: #2ba6cb;border-color: #2285a2;color: #FFFFFF;transition: background-color 300ms ease-out;"/>
        </div>
        <div class="name-field medium-4 columns">
            <dx:ASPxButton runat="server" ID="btnCancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" EnableClientSideAPI="true" Native="true" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem;font-size: 1rem;background-color: #2ba6cb;border-color: #2285a2;color: #FFFFFF;transition: background-color 300ms ease-out;" CssClass="button" />
        </div>
        <div class="name-field medium-4 columns">
            <dx:ASPxButton runat="server" ID="btnDelete" UseSubmitBehavior="false"
                            AutoPostBack="false" EnableViewState="false" Width="91px"
                            Enabled='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).CanDeleteAppointment %>'
                            CausesValidation="False" Native="true" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem;font-size: 1rem;color: #FFFFFF;transition: background-color 300ms ease-out;" CssClass="button warning"/>
        </div>

    </div>
    <div class="row">
        <dxwschsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlId='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).ControlId %>' />
    </div>
</div>
<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
    ASPxAppointmentForm = ASPx.CreateClass(ASPxClientFormBase, {
        Initialize: function () {
            this.isValid = true;
            this.isRecurrenceValid = true;
            this.controls.edtStartDate.Validation.AddHandler(ASPx.CreateDelegate(this.OnEdtStartDateValidate, this));
            this.controls.edtEndDate.Validation.AddHandler(ASPx.CreateDelegate(this.OnEdtEndDateValidate, this));
            this.controls.edtStartDate.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateStartDateTimeValue, this));
            this.controls.edtEndDate.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateEndDateTimeValue, this));
            this.controls.edtStartTime.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateStartDateTimeValue, this));
            this.controls.edtEndTime.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateEndDateTimeValue, this));
            this.controls.chkAllDay.CheckedChanged.AddHandler(ASPx.CreateDelegate(this.OnChkAllDayCheckedChanged, this));
            if (this.controls.AppointmentRecurrenceForm1)
                this.controls.AppointmentRecurrenceForm1.ValidationCompleted.AddHandler(ASPx.CreateDelegate(this.OnRecurrenceRangeControlValidationCompleted, this));
            this.UpdateTimeEditorsVisibility();
            if (this.controls.chkReminder)
                this.controls.chkReminder.CheckedChanged.AddHandler(ASPx.CreateDelegate(this.OnChkReminderCheckedChanged, this));
            if (this.controls.edtMultiResource)
                this.controls.edtMultiResource.SelectedIndexChanged.AddHandler(ASPx.CreateDelegate(this.OnEdtMultiResourceSelectedIndexChanged, this));
            var start = this.controls.edtStartDate.GetValue();
            var end = this.controls.edtEndDate.GetValue();
            var duration = ASPxClientTimeInterval.CalculateDuration(start, end);
            this.appointmentInterval = new ASPxClientTimeInterval(start, duration);
            this.appointmentInterval.SetAllDay(this.controls.chkAllDay.GetValue());
            this.UpdateDateTimeEditors();
        },
        OnEdtMultiResourceSelectedIndexChanged: function (s, e) {
            var resourceNames = new Array();
            var items = s.GetSelectedItems();
            var count = items.length;
            if (count > 0) {
                for (var i = 0; i < count; i++)
                    resourceNames.push(items[i].text);
            }
            else
                resourceNames.push(ddResource.cp_Caption_ResourceNone);
            ddResource.SetValue(resourceNames.join(', '));
        },
        OnEdtStartDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnEdtEndDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnUpdateEndDateTimeValue: function (s, e) {
            var isAllDay = this.controls.chkAllDay.GetValue();
            var date = ASPxSchedulerDateTimeHelper.TruncToDate(this.controls.edtEndDate.GetDate());
            if (isAllDay) 
                date = ASPxSchedulerDateTimeHelper.AddDays(date, 1);
            var time = ASPxSchedulerDateTimeHelper.ToDayTime(this.controls.edtEndTime.GetDate());
            var dateTime = ASPxSchedulerDateTimeHelper.AddTimeSpan(date, time);
            this.appointmentInterval.SetEnd(dateTime);
            this.UpdateDateTimeEditors();
            this.Validate();            
        },
        OnUpdateStartDateTimeValue: function (s, e) {
            var date = ASPxSchedulerDateTimeHelper.TruncToDate(this.controls.edtStartDate.GetDate());
            var time = ASPxSchedulerDateTimeHelper.ToDayTime(this.controls.edtStartTime.GetDate());
            var dateTime = ASPxSchedulerDateTimeHelper.AddTimeSpan(date, time);
            this.appointmentInterval.SetStart(dateTime);
            this.UpdateDateTimeEditors();
            if (this.controls.AppointmentRecurrenceForm1)
                this.controls.AppointmentRecurrenceForm1.SetStart(dateTime);
            this.Validate();
        },
        OnChkReminderCheckedChanged: function (s, e) {
            var isReminderEnabled = this.controls.chkReminder.GetValue();
            if (isReminderEnabled)
                this.controls.cbReminder.SetSelectedIndex(3);
            else
                this.controls.cbReminder.SetSelectedIndex(-1);
            this.controls.cbReminder.SetEnabled(isReminderEnabled);
        },
        OnChkAllDayCheckedChanged: function(s, e) {
            this.UpdateTimeEditorsVisibility();
            var isAllDay = this.controls.chkAllDay.GetValue();
            this.appointmentInterval.SetAllDay(isAllDay);
            this.UpdateDateTimeEditors();
        },
        UpdateDateTimeEditors: function() {
            var isAllDay = this.controls.chkAllDay.GetValue();
            this.controls.edtStartDate.SetValue(this.appointmentInterval.GetStart());
            var end = this.appointmentInterval.GetEnd();
            if (isAllDay) {
                end = ASPxSchedulerDateTimeHelper.AddDays(end, -1);
            }
            this.controls.edtEndDate.SetValue(end);
            this.controls.edtStartTime.SetValue(this.appointmentInterval.GetStart());
            this.controls.edtEndTime.SetValue(end);
        },
        UpdateTimeEditorsVisibility: function() {
            var isAllDay = this.controls.chkAllDay.GetValue();
            var visible = (isAllDay) ? "none" : "";
            var startRoot = ASPx.GetParentById(this.controls.edtStartTime.GetMainElement(), "edtStartTimeLayoutRoot");
            var endRoot = ASPx.GetParentById(this.controls.edtEndTime.GetMainElement(), "edtEndTimeLayoutRoot");
            //startRoot.style.display = visible;
            //endRoot.style.display = visible;
        },
        Validate: function () {
            this.isValid = ASPxClientEdit.ValidateEditorsInContainer(null);
            this.controls.btnOk.SetEnabled(this.isValid && this.isRecurrenceValid);
        },
        OnRecurrenceRangeControlValidationCompleted: function(s, e) {
            if (!this.controls.AppointmentRecurrenceForm1)
                return;
            this.isRecurrenceValid = this.controls.AppointmentRecurrenceForm1.IsValid();
            this.controls.btnOk.SetEnabled(this.isValid && this.isRecurrenceValid);
        }
    });
</script>

