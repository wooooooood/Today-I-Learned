//ref: https://www.codingwithcalvin.net/xamarin-forms-debouncing-an-entry-field/
private CancellationTokenSource _throttleCts = new CancellationTokenSource();

private async Task TextInput_TextChangedAsync(object sender, TextChangedEventArgs e)
{
    try
    {
        Interlocked.Exchange(ref _throttleCts, new CancellationTokenSource()).Cancel();

        //NOTE THE 500 HERE - WHICH IS THE TIME TO WAIT
        await Task.Delay(TimeSpan.FromMilliseconds(500), _throttleCts.Token)
            .ContinueWith(async task => {
              //THE "ACTUAL" METHOD HERE 
            },
            CancellationToken.None,
            TaskContinuationOptions.OnlyOnRanToCompletion,
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    catch
    {
        //Ignore any Threading errors
    }
}
