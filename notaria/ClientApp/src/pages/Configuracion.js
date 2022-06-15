import React, { useState } from "react";
import TitleHeader from "../components/title/TitleHeader";
import TopBar from "../components/topbar/TopBar";
import SideBar from "../components/sidebar/SideBar";
import Input from "../components/input/Input";
import Button from "../components/button/Button";
import editBlackIcon from "../icons/editBlackIcon.png";
import styles from "../scss/pages/Configuracion.module.scss";

export default function Configuracion() {
  const [openBar, setOpenBar] = useState("");
  const [activated, setActivated] = useState(true);

  const handleGetStateBar = (openBar) => {
    setOpenBar(openBar);
  };

  const handleDesactivated = () => {
    if (activated) {
      setActivated(false);
    }
  };

  const handleActivated = () => {
    if (!activated) {
      setActivated(true);
    }
  };

  const handleClick = () => {
    console.log("Guardado");
  };

  console.log(activated);
  return (
    <div className={styles.configuracionContainer}>
      <div
        className={
          !openBar
            ? styles.sideBarContainer
            : `${styles.sideBarContainer} ${styles.sideBarClose}`
        }
      >
        <SideBar handleStateBar={handleGetStateBar} />
      </div>
      <div
        className={
          !openBar
            ? styles.contentContainer
            : `${styles.contentContainer} ${styles.contentContainerClose}`
        }
      >
        <div
          className={
            !openBar
              ? styles.topBarContentContainer
              : `${styles.topBarContentContainer} ${styles.topBarContentContainerClose}`
          }
        >
          <div className={styles.topBarContainer}>
            <TopBar />
          </div>
          <div className={styles.titleContainer}>
            <TitleHeader text="Usuario" withoutIcon />
          </div>
          <div className={styles.formContainer}>
            <form>
              <div className={styles.rowOneContainer}>
                <div className={styles.inputNombre}>
                  <Input
                    label="Nombre"
                    disabled={activated}
                    inputOverLabel
                    icon={editBlackIcon}
                    placeholder="Nombre"
                    type="text"
                    variant="inputCreateUser"
                    onClick={handleDesactivated}
                  />
                </div>
                <div className={styles.inputApellido}>
                  <Input
                    label="Apellido"
                    disabled={activated}
                    inputOverLabel
                    icon={editBlackIcon}
                    placeholder="Apellido"
                    type="text"
                    variant="inputCreateUser"
                    onClick={handleDesactivated}
                  />
                </div>
              </div>
              <div className={styles.rowTwoContainer}>
                <div className={styles.inputApellido}>
                  <Input
                    label="Correo"
                    disabled={activated}
                    inputOverLabel
                    icon={editBlackIcon}
                    placeholder="Correo"
                    type="email"
                    variant="inputCreateUser"
                    onClick={handleDesactivated}
                  />
                </div>
              </div>
              <div className={styles.rowThreeContainer}>
                <div className={styles.inputContraseña}>
                  <Input
                    label="Contraseña"
                    disabled={activated}
                    inputOverLabel
                    icon={editBlackIcon}
                    placeholder="********"
                    type="password"
                    variant="inputCreateUser"
                    onClick={handleDesactivated}
                  />
                </div>
                <div className={styles.inputConfirmarContraseña}>
                  <Input
                    label="Confirmar Contraseña"
                    disabled={activated}
                    inputOverLabel
                    icon={editBlackIcon}
                    placeholder="********"
                    type="password"
                    variant="inputCreateUser"
                    onClick={handleDesactivated}
                  />
                </div>
              </div>
              <div className={styles.inputCheckboxContainer}>
                <Input
                  type="checkbox"
                  label="Modificar vencidos"
                  labelRight
                  variant="inputCheckboxBackground"
                  labelWithBackground
                />
              </div>
              <div className={styles.buttonContainer}>
                <Button
                  variant="saveUser"
                  text="Guardar cambios"
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
