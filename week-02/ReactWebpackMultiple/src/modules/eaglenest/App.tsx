import React, { useState } from 'react';

const unangPangalan = '';
const unangDescription = '';

const App: React.FC = () => {
  const [pangalan, ilagayAngPangalan] = useState(unangPangalan);
  const [description, ilagayAngDescription] = useState(unangDescription);

  // const processA = () => {
  //   console.log(name);
  //   console.log(description);
  // };

  return (
    <>
      <input
        type="text"
        value={pangalan}
        onChange={(pangyayariSaPangalan) => {
          ilagayAngPangalan(pangyayariSaPangalan.target.value);
          ilagayAngDescription(pangalan);
        }}
      />

      <br />

      <textarea
        value={description}
        onChange={(pangyayariSaDescription) => {
          ilagayAngDescription(pangyayariSaDescription.target.value);
        }}
      ></textarea>

      <br />

      <button
        onClick={() => {
          ilagayAngDescription(pangalan);
        }}
      >
        Copy to Description
      </button>
    </>
  );
};

export default App;
