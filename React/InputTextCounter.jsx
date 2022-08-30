import React, { useState } from "react";

export default function App() {
  const limit = 30;
  const [inputText, setInputText] = useState("");
  const onInputChange = (e) => {  //(e: React.ChangeEvent<HTMLInputElement>) in tsx
    if (e.target.value.length > limit) {
      e.target.value = e.target.value.substring(0, limit);
    }
    setInputText(e.target.value);
  };

  return (
    <>
      <input onChange={onInputChange} placeholder="Type in.." />
      <div>({inputText.length}/{limit})</div>
    </>
  );
}
