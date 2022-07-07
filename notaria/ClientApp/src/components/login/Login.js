import React, { useState, useEffect } from "react";
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import Button from "../button/Button";
import Input from "../input/Input";
import logo from "../../images/logo.png";
import imageSide from "../../images/imgLogin.png";
import styles from "./Login.module.scss";

export default function Login(props) {
    const [user, setUser] = useState({ Correo: '', Clave: '' });
    let navigate = useNavigate();
    const [sesion, setSesion] = useState();
    const [loginToken, setLoginToken] = useState("");
  
    const URL = "https://localhost:7028/api/Login/Login";
    const Login = (e) => {
        e.preventDefault();
        const data = { Correo: user.Correo, Clave: user.Clave }
        axios.post(URL, data)
            .then((response) => {
                //const serializedState = JSON.stringify(result.data);
                //console.log(serializedState)
                console.log(response)
                //var a = localStorage.setItem('myData', serializedState);
                //console.log("A: ", a)
                //const user = result.data.userDetails;
                /*if (response.status === 200)
                    navigate('/inicio')
                else {
                    //setSesion(false);
                    //console.log(sesion)
                }*/
                setLoginToken(response.data.data);
            }).catch(function (error) {
                console.log(error);
            })
    }

    const onChange = (e) => {
        e.persist();
        setUser({ ...user, [e.target.name]: e.target.value });
    }

    const getUsers = () => {
        const URL = "https://localhost:7028/api/Usuario";
        const config = {
            headers: {
                Authorization: "Bearer " + loginToken
            }
        }
        axios.get(URL, config)
            .then((response) => {
                console.log('get users: ',response);
            }).catch(function (error) {
                console.log(error);
            })
    }

    return (
        <div className={styles.loginContainer}>
            <div className={styles.imageContainer}>
                <img className={styles.sideImage} src={imageSide} alt="imagen login" />
            </div>
            <div className={styles.formContainer}>
                <div className={styles.contentContainer}>
                    <div className={styles.logoContainer}>
                        <img className={styles.logo} src={logo} alt="Logo" />
                    </div>
                    <div className={styles.form}>
                        <form onSubmit={Login}>
                            <div className={styles.inputContainer}>
                                <Input
                                    id="Correo"
                                    name="Correo"
                                    type="email"
                                    placeholder="example@example.com"
                                    label="Correo"
                                    onChange={onChange}
                                    variant="inputLogin"
                                />
                            </div>
                            <div className={styles.inputContainer}>
                                <Input
                                    id="Clave"
                                    name="Clave"
                                    type="password"
                                    placeholder="***********"
                                    label="Contraseña"
                                    onChange={onChange}
                                    variant="inputLogin"
                                />
                            </div>
                            <div className={styles.forgetPassword}>
                                <a href="/">¿Olvidaste tu contraseña?</a>
                            </div>
                            <div className={styles.inputContainerCheckBox}>
                                <Input
                                    type="checkbox"
                                    label="Recordar contraseña"
                                    labelRight
                                    variant="inputCheckbox"
                                />
                            </div>
                            <div className={styles.buttonContainer}>
                                <Button
                                    variant="loginButton"
                                    text="Iniciar sesión"
                                    type="submit"
                                />
                            </div>
                            <div className={styles.buttonContainer}>
                                <Button
                                    variant="loginButton"
                                    text="Obtener usuarios"
                                    type="button"
                                    onClick={getUsers}
                                />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}
