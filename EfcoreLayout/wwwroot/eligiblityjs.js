function Calculate() {
  
   
    const monthlyincome = document.querySelector("#monthlyincome").value;
  
    
    // Calculating total payment
    const eligiblity = 60*(0.6*monthlyincome).toFixed(2);
  
    document.querySelector("#eligiblity")
        .innerHTML = "Eligiblity : (₹)" + eligiblity;
}  