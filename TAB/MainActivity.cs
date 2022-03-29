using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace TAB
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Map _map;
        private List _list;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            _map = new Map();
            _list = new List();
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _list).Commit();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.map:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _map).Commit();

                    return true;

                case Resource.Id.list:
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, +_list).Commit();
                    return true;

                
            return false;
        }
    }
}