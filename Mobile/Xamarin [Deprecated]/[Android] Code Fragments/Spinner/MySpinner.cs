using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace wooooooood.Droid
{
    class MySpinner : Spinner
    {
        MyAdapter adapter;
        IList<string> items;

        public IList<string> ItemsSource
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    adapter.Clear();

                    foreach (string item in items)
                    {
                        adapter.Add(item);
                    }
                }
            }
        }

        public string SelectedObject
        {
            get
            {
                return (string)GetItemAtPosition(SelectedItemPosition);
            }
            set
            {
                if (items != null)
                {
                    int index = items.IndexOf(value);
                    if (index != -1)
                    {
                        SetSelection(index);
                    }
                }
            }
        }

        public MySpinner(Context context) : base(context)
        {
            ItemSelected += OnBindableSpinnerItemSelected;

            adapter = new MyAdapter(context, global::Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(global::Android.Resource.Layout.SimpleSpinnerDropDownItem);
            Adapter = adapter;
        }

        void OnBindableSpinnerItemSelected(object sender, ItemSelectedEventArgs args)
        {
            SelectedObject = (string)GetItemAtPosition(args.Position);
        }
    }

    class MyAdapter : ArrayAdapter
    {
        public MyAdapter(Context context, int resourceID) : base(context, resourceID)
        {
        }

        public override bool IsEnabled(int position)
        {
            if (position == 0) //hint
                return false;
            else
                return true;
        }

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            var view = base.GetDropDownView(position, convertView, parent);
            var textView = (TextView)view;

            if (position == 0)
                textView.SetTextColor(Android.Graphics.Color.Gray);
            else
                textView.SetTextColor(Android.Graphics.Color.Black);

            return view;
        }
    }
}