package edu.birzeit.myapplication;

        import edu.birzeit.myapplication.models.TrustedContact;
        import edu.birzeit.myapplication.models.UserInfo;
        import retrofit2.Call;
        import retrofit2.Callback;
        import retrofit2.Response;

        import android.app.DatePickerDialog;
        import android.content.Intent;
        import android.support.v7.app.AppCompatActivity;
        import android.os.Bundle;
        import android.Manifest;
        import android.app.ProgressDialog;
        import android.util.Log;
        import android.view.View;
        import android.widget.Button;
        import android.widget.CheckBox;
        import android.widget.DatePicker;
        import android.widget.EditText;
        import android.widget.RadioButton;
        import android.widget.RadioGroup;
        import android.widget.Toast;

        import java.util.Calendar;
        import java.util.List;
        import java.util.regex.Matcher;
        import java.util.regex.Pattern;

public class SignUp extends AppCompatActivity implements View.OnClickListener{

    private EditText nameEditText, emailEditText, passwordEditText, passwordAgainEditText,birthdayEditText;
    private RadioGroup genderRadioGroup;
    private Button signUpButton;
    private DatePickerDialog datePickerDialog;
    private CheckBox termsConditions;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_up);

        //Bind views with their ids
        bindViews();

        //Set listeners of views
        setViewActions();

        //Create DatePickerDialog to show a calendar to user to select birthdate
        prepareDatePickerDialog();

    }

    private void bindViews() {
        nameEditText=(EditText)findViewById(R.id.signUp_userName_editText);
        emailEditText=(EditText)findViewById(R.id.signUp_email_editText);
        passwordEditText=(EditText)findViewById(R.id.signUp_password_editText);
        passwordAgainEditText=(EditText)findViewById(R.id.signUp_passwordAgain_editText);
        birthdayEditText=(EditText)findViewById(R.id.signUp_birthday_editText);
        genderRadioGroup=(RadioGroup)findViewById(R.id.signUp_gender_radioGroup);
        signUpButton=(Button)findViewById(R.id.signUp_signUp_button);
        termsConditions = (CheckBox) findViewById(R.id.signUp_termsConditions_checkBox);
    }

    private boolean validate(EditText editText) {
        // check the lenght of the enter data in EditText and give error if its empty
        if (editText.getText().toString().trim().length() > 0) {
            return true; // returs true if field is not empty
        }
        editText.setError("Please Fill This");
        editText.requestFocus();
        return false;
    }

    private void setViewActions() {
        birthdayEditText.setOnClickListener(this);
        signUpButton.setOnClickListener(this);
    }

    private void prepareDatePickerDialog() {
        //Get current date
        Calendar calendar=Calendar.getInstance();

        //Create datePickerDialog with initial date which is current and decide what happens when a date is selected.
        datePickerDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                //When a date is selected, it comes here.
                //Change birthdayEdittext's text and dismiss dialog.
                birthdayEditText.setText(dayOfMonth+"/"+monthOfYear+"/"+year);
                datePickerDialog.dismiss();
            }
        },calendar.get(Calendar.YEAR),calendar.get(Calendar.MONTH),calendar.get(Calendar.DAY_OF_MONTH));
    }

    private void showToastWithFormValues() {

        //Get edittexts values
        String name=nameEditText.getText().toString().trim();
        String email=emailEditText.getText().toString().trim();
        String pass=passwordEditText.getText().toString().trim();
        String passAgain=passwordAgainEditText.getText().toString().trim();
        String birthday=birthdayEditText.getText().toString().trim();

        //Get gender
        RadioButton selectedRadioButton=(RadioButton)findViewById(genderRadioGroup.getCheckedRadioButtonId());
        String gender=selectedRadioButton==null ? "":selectedRadioButton.getText().toString();

        // Pattern match for email id
        String regEx = "[a-zA-Z0-9._-]+@[a-z]+\\.+[a-z]+"; //Email Validation pattern
        Pattern p = Pattern.compile(regEx);
        Matcher m = p.matcher(email);

        //Check all fields
        if(m.find()&&termsConditions.isChecked()&&!name.equals("")&&!email.equals("")&&!pass.equals("")&&!passAgain.equals("")&&!birthday.equals("")&&!gender.equals("")){

            //Check if pass and passAgain are the same
            if(pass.equals(passAgain)){
                //Everything allright
                Toast.makeText(this,"every thing is ok :)",Toast.LENGTH_SHORT).show();
                signUp(name, email, pass, birthday, gender);

                    Intent intent  = new Intent(SignUp.this, logIn.class);
                    SignUp.this.startActivity(intent);

        }
            else{
                Toast.makeText(this,"passwords_must_be_the_same",Toast.LENGTH_SHORT).show();
            }

        }
        // Make sure user should check Terms and Conditions checkbox
        else if (!termsConditions.isChecked()) {
            Toast.makeText(this, "Please select Terms and Conditions.", Toast.LENGTH_SHORT).show();
        }
        // Check if email id valid or not
        else if (!m.find()) {
            Toast.makeText(this, "Your Email Id is Invalid.", Toast.LENGTH_SHORT).show();
        }
        else{
            Toast.makeText(this,"no_field_can_be_empty",Toast.LENGTH_SHORT).show();
        }

    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.signUp_birthday_editText:
                datePickerDialog.show();
                break;
            case R.id.signUp_signUp_button:
                showToastWithFormValues();
                break;
        }
    }


    /*
    private void signUp(String name, String email, String password, String birthday, String gender) {

        // display a progress dialog
        final ProgressDialog progressDialog = new ProgressDialog(SignUp.this);
        progressDialog.setCancelable(false); // set cancelable to false
        progressDialog.setMessage("Please Wait"); // set message
        progressDialog.show(); // show progress dialog

        // set user information
        if(gender.equals("male")) // set gender
            gender = "m";
        else
            gender = "f";
        UserInfo user = new UserInfo(name, email, password, gender, birthday); // save date

        // Api is a class in which we define a method getClient() that returns the API Interface class object
        // registration is a POST request type method in which we are sending our field's data
        String response = Api.getClient().createUser(user);
        //String response = "no";
        // check response
        switch(response) {
            case "ok" :
                // in this method we will get the response from API
                progressDialog.dismiss(); //dismiss progress dialog
                // display the message getting from web api
                Toast.makeText(SignUp.this, "sign up done.", Toast.LENGTH_SHORT).show();
                break;

            case "no" :
                // in this method we will get the response from API
                progressDialog.dismiss(); //dismiss progress dialog
                // display an error message
                Toast.makeText(SignUp.this, "can't sign up correctly, please try again.", Toast.LENGTH_LONG).show();
                break;

            case "repeated email":
                // in this method we will get the response from API
                progressDialog.dismiss(); //dismiss progress dialog
                // display an error message
                Toast.makeText(SignUp.this, "this email is used, try another one.", Toast.LENGTH_SHORT).show();
                break;

            default :
                // if error occurs in network transaction then we can get the error in this method.
                progressDialog.dismiss(); //dismiss progress dialog
                // display an error message
                Toast.makeText(SignUp.this, "can't connect to server, check internet connection.", Toast.LENGTH_LONG).show();
        }

    }
    */



    private void signUp(String name, String email, String password, String birthday, String gender) {

        // display a progress dialog
       // final ProgressDialog progressDialog = new ProgressDialog(SignUp.this);
        //progressDialog.setCancelable(false); // set cancelable to false
        //progressDialog.setMessage("Please Wait"); // set message
        //progressDialog.show(); // show progress dialog

        // set user information
        if(gender.equals("male")) // set gender
            gender = "m";
        else
            gender = "f";
        UserInfo user = new UserInfo(name, email, password, gender, birthday); // save date

        // Api is a class in which we define a method getClient() that returns the API Interface class object
        // registration is a POST request type method in which we are sending our field's data
        Call<UserInfo> call = Api.getClient().createUser(user);

            call.enqueue(new Callback<UserInfo>() {
                @Override
                public void onResponse(Call<UserInfo> call, Response<UserInfo> response) {
                    if(response.isSuccessful()){
                        Toast.makeText(SignUp.this, "User created successfully!", Toast.LENGTH_SHORT).show();
                    }
                }

                @Override
                public void onFailure(Call<UserInfo> call, Throwable t) {
                    Log.e("ERROR: ", t.getMessage());
                }
            });

    }


}
