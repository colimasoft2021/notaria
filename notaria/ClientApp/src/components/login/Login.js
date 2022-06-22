import React from "react";
import { useNavigate } from "react-router-dom";
import Button from "../button/Button";
import Input from "../input/Input";
import logo from "../../images/logo.png";
import imageSide from "../../images/imgLogin.png";
import styles from "./Login.module.scss";

export default function Login() {
    let navigate = useNavigate();

    const handleClick = () => {
        navigate("/inicio");
    };

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
                        <form>
                            <div className={styles.inputContainer}>
                                <Input
                                    type="email"
                                    placeholder="example@example.com"
                                    label="Correo"
                                    variant="inputLogin"
                                />
                            </div>
                            <div className={styles.inputContainer}>
                                <Input
                                    type="password"
                                    placeholder="***********"
                                    label="Contraseña"
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
                                    onClick={handleClick}
                                />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}
