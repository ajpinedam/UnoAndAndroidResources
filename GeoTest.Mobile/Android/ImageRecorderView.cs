using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace GeoTest.Droid;

public class ImageRecorderView : AndroidX.Fragment.App.Fragment
{
    public override View? OnCreateView(LayoutInflater? inflater, ViewGroup? container, Bundle? savedInstanceState)
    {
        var frame = inflater?.Inflate(Resource.Layout.image_recorder_view, container, false) as FrameLayout;

        if (frame is not null)
        {
            frame.SetBackgroundColor(Resources.GetColor(Resource.Color.white_smoke));

            var minHeight = (int)Resources.GetDimension(Resource.Dimension.recorder_fragment_height);
            frame.SetMinimumHeight(minHeight);

            if (frame.FindViewById<Android.Widget.Button>(Resource.Id.myButton) is { } button)
            {
                button.SetText(Resource.String.FrameButtonTitle);
            }
        }

        return frame;
    }
}
