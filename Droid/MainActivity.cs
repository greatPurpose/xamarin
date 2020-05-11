
//using Android.App.ActionBar;
//using Android.app.Activity;
//using Android.content.Intent;
//using Android.os.Bundle;
//using Android.util.Log;
//using Android.view.Menu;
//using Android.view.MenuItem;
//using Android.view.View;
using Android.Views.OnClickListener;
//using Android.widget.Button;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
public class MainActivity : Application
{

    private string TAG = typeof(this);//this.getClass().getName();

    private Button mStartLocalMusicBtn;

    private Button mStartLocalGallleryBtn;

    private Button mStartLocalVideoBtn;

    private Button mStartConfigureBtn;

    //public override
    protected void onCreate(Bundle savedInstanceState)
    {
        onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        RemoteDisplayManager.INSTANCE.initializeRemoteDisplayManager(this);
        this.mStartLocalMusicBtn = ((Button)(findViewById(R.id.start_radio_button)));
        this.mStartLocalGallleryBtn = ((Button)(findViewById(R.id.start_local_gallery_button)));
        this.mStartLocalVideoBtn = ((Button)(findViewById(R.id.start_local_video_button)));
        this.mStartConfigureBtn = ((Button)(findViewById(R.id.start_configure_button)));
        this.mStartLocalGallleryBtn.SetOnClickListener(new Button());
        this.mStartLocalMusicBtn.SetOnClickListener(new OnClickListener());
        this.mStartLocalVideoBtn.SetOnClickListener(new OnClickListener());
        this.mStartConfigureBtn.SetOnClickListener(new OnClickListener());
    }

    [Override()]
    protected void onResume()
    {
        base.onResume();
        if (RemoteDisplayManager.INSTANCE.isConnectedToRemoteDisplay())
        {
            RemoteDisplayManager.INSTANCE.displayStandByPresentation(this);
            // Enable UI
            this.mStartLocalMusicBtn.setEnabled(true);
            this.mStartLocalGallleryBtn.setEnabled(true);
            this.mStartLocalVideoBtn.setEnabled(true);
        }
        else
        {
            // Disable UI
            this.mStartLocalMusicBtn.setEnabled(true);
            this.mStartLocalGallleryBtn.setEnabled(false);
            this.mStartLocalVideoBtn.setEnabled(true);
        }

    }

    [Override()]
    protected void onPause()
    {
        base.onPause();
        RemoteDisplayManager.INSTANCE.hideStandByPresentation();
    }

    [Override()]
    protected void onDestroy()
    {
        //  TODO Auto-generated method stub
        base.onDestroy();
        RemoteDisplayManager.INSTANCE.shutDown();
    }

    [Override()]
    public bool onCreateOptionsMenu(Menu menu)
    {
        //  Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    [Override()]
    public bool onOptionsItemSelected(MenuItem item)
    {
        switch (item.getItemId())
        {
            case R.id.action_settings:
                this.startDisplayListView();
                break;
        }
        return true;
    }

    private void startDisplayListView()
    {
        Log.d(this.TAG, "startDisplayListView");
        Intent displayListIntent = new Intent(this, DisplayActivity.class);
        startActivity(displayListIntent);
}

private void startLocalMusicView()
{
    Log.d(this.TAG, "startLocalMusicView");
    Intent localMusicIntent = new Intent(this, LocalMusicActivity.class);
        startActivity(localMusicIntent);
    }
    
    private void startLocalVideoView()
{
    Log.d(this.TAG, "startLocalVideoView");
    Intent localVideoIntent = new Intent(this, LocalVideoActivity.class);
        startActivity(localVideoIntent);
    }
    
    private void startLocalGallery()
{
    Intent localGalleryIntent = new Intent(this, LocalGalleryActivity.class);
        startActivity(localGalleryIntent);
    }
}
