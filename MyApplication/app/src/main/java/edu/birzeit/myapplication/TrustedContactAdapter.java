package edu.birzeit.myapplication;

import edu.birzeit.myapplication.models.TrustedContact;
import android.content.Context;
import android.content.Intent;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;


import java.util.List;
public class TrustedContactAdapter  extends ArrayAdapter<TrustedContact> {

    private Context context;
    private List<TrustedContact> trustContacts;

    public TrustedContactAdapter(@NonNull Context context, @LayoutRes int resource, @NonNull List<TrustedContact> objects) {
        super(context, resource, objects);
        this.context = context;
        this.trustContacts = objects;
    }

    @Override
    public View getView(final int pos, View convertView, ViewGroup parent){
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = inflater.inflate(R.layout.list_trusted_contact, parent, false);


        TextView txtUsername = (TextView) rowView.findViewById(R.id.txtTrustContactName);

        txtUsername.setText(String.format("  %s  ", trustContacts.get(pos).getName()));

        rowView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //start Activity User Form
                Intent intent = new Intent(context, trustedContactActivity.class);
                intent.putExtra("trustContact_id", String.valueOf(trustContacts.get(pos).getId()));
                intent.putExtra("trustContact_name", trustContacts.get(pos).getName());
                intent.putExtra("trustContact_phone", trustContacts.get(pos).getPhone());
                intent.putExtra("trustContact_ContactOrder",String.valueOf(trustContacts.get(pos).getContactOrder()));

                context.startActivity(intent);
            }
        });

        return rowView;
    }

}
