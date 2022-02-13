
  fetch("https://localhost:5001/AppUser").then((data) => {
      console.log(data);
    return data.json();
  }).then((completedata)=> {   
    console.log(completedata);
      let users="";
      completedata.map((values)=>{
users+=`<tr>
<th scope="row">${values.id}</th>
<td>${values.name}</td>
<td>${values.age}</td>
<td>${values.state}</td>
</tr>`;
});
document.getElementById("usertbl").innerHTML=users;
}).catch((error) => {
    console.log("FETCH ERROR:", error);
});
  