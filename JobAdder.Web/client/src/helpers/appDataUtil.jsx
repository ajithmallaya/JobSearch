export const getAppDataById = (id) => {
    let data;
    const inputElement = document.getElementById(id);
  
    if (inputElement) {
        data = inputElement.value;
       return data;
    }
  }; 