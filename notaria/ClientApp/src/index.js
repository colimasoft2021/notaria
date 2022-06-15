import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "../src/scss/globals.scss";
import App from "./App";
import Inicio from "./pages/Inicio";
import Tramite from "./pages/Tramite";
import CatalogoActos from "./pages/CatalogoActos";
import CatalogoResponsables from "./pages/CatalogoResponsables";
import SeguimientoTramites from "./pages/SeguimientoTramites";
import Configuracion from "./pages/Configuracion";
import reportWebVitals from "./reportWebVitals";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="/inicio" element={<Inicio />} />
      <Route path="/tramite" element={<Tramite />} />
      <Route path="/catalogo-actos" element={<CatalogoActos />} />
      <Route path="/catalogo-responsable" element={<CatalogoResponsables />} />
      <Route path="/seguimiento-tramites" element={<SeguimientoTramites />} />
      <Route path="/configuracion" element={<Configuracion />} />
    </Routes>
  </BrowserRouter>,
  rootElement);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
