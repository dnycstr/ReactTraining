import { Field, Form, Formik } from 'formik';
import React from 'react';
import * as Yup from 'yup';

const contactValidation = Yup.object().shape({
  pangalan: Yup.string()
    .max(100, 'Pangalan exceeds 100 characters')
    .required('Pangalan is required'),
  email: Yup.string()
    .email('Please enter a valid email address')
    .max(100, 'Email exceeds 100 characters')
    .required('Email is required'),
  age: Yup.number().min(10).max(100),
});

interface contactViewModel {
  pangalan: string;
  email: string;
  edad: number;
}

const initialContact: contactViewModel = {
  pangalan: '',
  email: '',
  edad: 0,
};

const App: React.FC = () => {
  return (
    <>
      <h1>Contact Us</h1>
      <Formik
        initialValues={initialContact}
        validationSchema={contactValidation}
        onSubmit={async (values) => {
          console.log(values);
          //await new Promise((resolve) => setTimeout(resolve, 500));
          //alert(JSON.stringify(values, null, 2));
        }}
      >
        <Form>
          <label>Pangalan</label>
          <Field className="bg-red-400" name="pangalan" type="text" /> <br />
          <label>Email</label>
          <Field name="email" type="text" /> <br />
          <label>Edad</label>
          <Field name="edad" type="text" /> <br />
          <button type="button">Submit</button>
        </Form>
      </Formik>
    </>
  );
};

export default App;
