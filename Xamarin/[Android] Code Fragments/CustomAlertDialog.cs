//CustomAlertDialog.xml exists
void ShowCustomAlertDialog()
{
  var viewGroup = FindViewById<LinearLayout>(namespace.Android.Resource.Id.customAlertDialog);
  var dialogView = LayoutInflater.From(this).Inflate(namespace.Android.Resource.Layout.CustomAlertDialog, viewGroup, false);
  var alertDialogBuilder = new AlertDialog.Builder(this);

  alertDialogBuilder.SetCancelable(true);
  alertDialogBuilder.SetView(dialogView);
  alertDialogBuilder.SetNegativeButton("OK", (senderAlert, args) =>
  {
    alertDialogBuilder.Dispose();
  });

  dialogView.FindViewById<TextView>(namespace.Android.Resource.Id.titleTextView).Text = title;
  dialogView.FindViewById<TextView>(namespace.Android.Resource.Id.bodyTextView).Text = body;

  using (var alertDialog = alertDialogBuilder.Create())
  {
    alertDialog.Show();
  }
}
