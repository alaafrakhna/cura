package edu.birzeit.myapplication;


        import okhttp3.OkHttpClient;
// import okhttp3.logging.HttpLoggingInterceptor;
        import retrofit2.Retrofit;
        import retrofit2.converter.gson.GsonConverterFactory;

        import android.os.Bundle;
        import android.view.View;
        import android.widget.Button;
        import android.widget.TextView;
        import android.widget.Toast;
        import java.util.List;
        import retrofit2.Call;
        import retrofit2.Callback;
        import retrofit2.Response;
        import retrofit2.Retrofit;
        import retrofit2.converter.gson.GsonConverterFactory;

public class Api {

    //private static final String BASE_URL = "http://cura.eastus.cloudapp.azure.com/";

    private static final String BASE_URL = "https://triagingsystem.conveyor.cloud/";



    private static Retrofit retrofit = null;

    static ApiInterface getClient() {

        retrofit = new
                Retrofit.Builder().
                baseUrl(BASE_URL).
                addConverterFactory(GsonConverterFactory.create()).
                build();

        //Creating object for our interface
        ApiInterface api = retrofit.create(ApiInterface.class);
        return api;
    }
}