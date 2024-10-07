import { Routes, Route,NavLink  } from 'react-router-dom';
import {  useState  } from 'react';
import LengthConverter from './components/LengthConverter'
import WeightConverter from './components/WeightConverter'
import TemperatureConverter from './components/TemperatureConverter';
import ConversionHistory from './components/ConversionHistory';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "./App.css";

function App() {
  
  const [showing,setShowing] = useState<boolean>(true);

  const handleButtonClicked = () => {
    if (window.screen.width <=640) {
    setShowing(!showing)
    }    
  }
  return (
    <>
      <div> 
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <div className="container-fluid">
            <a className="navbar-brand" href="#" >Unit Converter Application</a>
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation" onClick={handleButtonClicked}>
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarSupportedContent" style={{ display: (showing ? 'none' : 'flex') }}>
              <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                <li className="nav-item">
                  <NavLink to="/Length" className="nav-link active">Length</NavLink>                 
                </li>
                <li className="nav-item">
                  <NavLink to="/Weight" className="nav-link active">Weight</NavLink>      
                </li>
                <li className="nav-item">
                  <NavLink to="/Temperature" className="nav-link active">Temperature</NavLink>    
                </li>
                <li className="nav-item">
                   <NavLink to="/ConversionHistory" className="nav-link active">Conversion History</NavLink>  
                </li>  
              </ul>      
            </div>
          </div>
        </nav> 
        </div>
        <ToastContainer />   
      <Routes>
        <Route path ="/" element={<LengthConverter />} />
        <Route path ="Length" element={<LengthConverter />} />
        <Route path ="Weight" element={<WeightConverter />} />
        <Route path ="Temperature" element={<TemperatureConverter />} />  
        <Route path ="ConversionHistory" element={<ConversionHistory />} />  
      </Routes>
  </>)
}

export default App
