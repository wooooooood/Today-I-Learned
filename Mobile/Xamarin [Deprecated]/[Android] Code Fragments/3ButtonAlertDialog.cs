void ShowThreeButtonAlertDialog()
{
    AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this); //this is Activity context
    alertDialogBuilder.SetTitle("Notice");
    alertDialogBuilder.SetMessage("Launching this missile will destroy the entire universe. Is this what you intended to do?");
    alertDialogBuilder.SetCancelable(true);

    alertDialogBuilder.SetPositiveButton("YYYEESSSS", (senderAlert, args) =>
    {
        //BLOW!
    });
    alertDialogBuilder.SetNegativeButton("NO", (senderAlert, args) =>
    {
        //NO
    });
    alertDialogBuilder.SetNeutralButton("Cancel", (senderAlert, args) =>
    {
        //alertDialogBuilder.Dispose();
    });

    var alerDialog = alertDialogBuilder.Create();
    alerDialog.Show();
}
