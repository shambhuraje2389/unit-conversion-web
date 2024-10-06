import { useEffect, useState,FormEvent } from 'react';
import {  toast } from 'react-toastify';


type Props = {
  type : number
}

function Converter({type} : Props) {

  const [lengthUnits,setUnits] = useState([]);

  const fetchUnits = async () => {
    try {
      const supabaseUrl = import.meta.env.VITE_UCAAPI_URL;

      const url=supabaseUrl+"unit?type="+type;
      const response = await fetch(url);
      const data = await response.json();   
      setUnits(data);
    } catch (error) {
      console.error("Error fetching unit options:", error);
    }
  };  

  useEffect(() => {
    fetchUnits();   
  }, []); 
  
  const [state, setState] = useState({
    input: "",
    source: "",
    target: "",
    output:""   
  });

  const [formErrors, setFormErrors] = useState({
    input: "",
    source: "",
    target: "",
  });

  const [outputResult,setoutputResult] = useState<string>(".....");

  let header='';
  if (type==1) {
    header = 'Length'
  } else if(type==2){
    header = 'Weight'
  }
  else if(type==3){
    header = 'Temparaure'
  }

  const onFieldChange = (event: any) => {
    
    //let value = event.target.value;    
    
    const { name, value } = event.target;

    setState({ ...state, [event.target.id]: value });
 

    // Perform validation
    if (name === "input" && value === "") {
      setFormErrors({
        ...formErrors,
        input: "Input value is required.",
      });
    } else if (name === "source" && value === "") {
      setFormErrors({
        ...formErrors,
        source: "Source unit is required.",
      });
    }  else if (name === "target" && value === "") {
      setFormErrors({
        ...formErrors,
        target: "Target unit is required.",
      });
    } else {
      // Clear validation errors if input is valid
      setFormErrors({
        ...formErrors,
        [name]: "",
      });
    }


  }; 

  const handleConvertButtonClicked = async (event: FormEvent<HTMLFormElement>) => {

    
    event.preventDefault();    
    console.log(state);

    const validationErrors={input: "",source: "",target: ""}
      if (state.input === "") {
        validationErrors.input = `Input value is required.`;
      } 
      if (state.source === "") {
        validationErrors.source = `Source unit is required.`;
      }
      if (state.target === "") {
        validationErrors.target = `Target unit is required.`;
      }
     

    // Update form errors
    setFormErrors(validationErrors);

    if (Object.values(validationErrors).every((error) => error === "")) {

    // POST request using fetch with async/await
    const requestOptions = {
      method: 'POST',
      headers: {  
        'Accept': 'application/json, text/plain, */*',
        'Content-Type': 'application/json' 
      },     
      body: JSON.stringify({ input: state.input,type:1,sourceunitid:state.source,targetunitid:state.target,output:''})
    };
    const supabaseUrl = import.meta.env.VITE_UCAAPI_URL;    
    const response = await fetch(supabaseUrl+'conversion', requestOptions);
    const data = await response.json();
    console.log(data);
   
    setoutputResult(data.output);   

    toast.success('Conversion successfully done.Please check the result', {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "colored"     
      });

  

  }else {
    toast.error('Form validation failed. Please check the errors.', {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
      theme: "colored"      
      });      
    console.log("Form validation failed. Please check the errors.");
  }
    
  };

  const handleClearButtonClicked = (event: any) => {
    event.preventDefault();    
    console.log(state);
    setState({
      input: "",
      source: "",
      target: "",
      output:""   
    });
    
    setFormErrors({
      input: "",
      source: "",
      target: "",
    });
   
    const result="...";
    setoutputResult(result);
  };

  

  return (    
     <div className="container p-2">    
     
       <form action="" className="row kg-row" onSubmit={handleConvertButtonClicked}>
            <div className="mb-3 row">
            <h4>Category : {header}</h4> 
            </div> 
            <div className="mb-3 row">
                <label className="col-sm-2 col-form-label" htmlFor="input">Value :</label>
                <div className="col-sm-10">
                  <input type="text" placeholder="Enter Value here" id="input"  name="input" value={state.input} className="form-control" onChange={onFieldChange} ></input>   
                  <span className="text-danger">{formErrors.input}</span>         
                </div>        
            </div> 
            <div className="mb-3 row">
                <label className="col-sm-2 col-form-label" htmlFor="source">Source unit:</label>
                <div className="col-sm-10">
                <select className="form-select" aria-label="Default select example" id="source" name="source"  value={state.source} onChange={onFieldChange}  >
                <option value=""></option>
                  {lengthUnits.map(({ id, name }) => (
                    <option key={id} value={id}>
                      {name}
                    </option>
                  ))}
                </select>    
                <span className="text-danger">{formErrors.source}</span>                     
                </div>        
            </div>   
            <div className="mb-3 row">
                <label className="col-sm-2 col-form-label" htmlFor="target">Target unit :</label>
                <div className="col-sm-10">          
                <select className="form-select" aria-label="Default select example" id="target" name="target" value={state.target}  onChange={onFieldChange}>
                <option value=""></option>
                  {lengthUnits.map(({ id, name }) => (
                    <option key={id} value={id}>
                      {name}
                    </option>
                  ))}
                </select> 
                <span className="text-danger">{formErrors.target}</span>                                      
                </div>        
            </div>  
            <div className="mb-3 row">
                <label className="col-sm-2 col-form-label"></label>
                <div className="col-sm-1">  
                  <button type="submit" className="btn btn-success">Convert</button>
                  </div>   
                  <div className="col-sm-1">      
                  <button type="button" className="btn btn-secondary"  onClick={handleClearButtonClicked}>Clear</button>
                </div>        
            </div> 
            <div className="mb-3 row alert alert-success">
                <label className="col-sm-2 col-form-label">Converted Result</label>
                <div className="col-sm-10">         
                <label className="col-sm-2 col-form-label">{outputResult}</label>
                </div>        
            </div>  
      </form>      
    </div>   
  )  
}

export default Converter
