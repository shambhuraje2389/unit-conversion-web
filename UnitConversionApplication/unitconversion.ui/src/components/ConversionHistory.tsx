import { useEffect, useState /*,useRef*/ } from 'react';
import {  toast } from 'react-toastify';


function ConversionHistory() {

  //const count = useRef(0);

  const [conversionLogs, setConversionLogs] = useState([{
    id:0,
    input:"",
    output:"",
    source:"",
    target:"",
    type:""
  }]);  
  
  useEffect(() => {
  //   const isDevMode = import.meta.env.VITE_IsDev;
  //   if(isDevMode){
  //   if (count.current !== 0) {
  //     populateConversionLogs();
  //   }
  //   count.current++;
  // }
  // else{
  //   populateConversionLogs();
  // }

  populateConversionLogs();

  }, []);


  return (    
     <div className="container p-2">
       <div className="mb-3 row">
         <h4>Conversion History</h4>        
      </div> 
      <div className="mb-3">
      <table className="table">
        <thead>        
          <tr>   
            <th>Id</th>   
            <th scope="col">Type</th>     
            <th scope="col">Input</th>
            <th scope="col">Source Unit</th>
            <th scope="col">Target Unit</th>
            <th scope="col">Output</th>
          </tr>
        </thead>
        <tbody>
        {conversionLogs.map(log =>
          <tr key={log.id}>
               <td>{log.id}</td>
               <td>{log.type}</td>
              <td>{log.input}</td>
              <td>{log.source}</td>
              <td>{log.target}</td>
              <td>{log.output}</td>
          </tr>
        )}        
        </tbody>
      </table>
      </div>
    </div>   
  )

  async function populateConversionLogs() {    

    const supabaseUrl = import.meta.env.VITE_UCAAPI_URL;
    const response = await fetch(supabaseUrl+'conversion');
    const data = await response.json();
    setConversionLogs(data);
    toast.success('Conversion History successfully loaded.', {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "colored"          
      });
  }
}

export default ConversionHistory
