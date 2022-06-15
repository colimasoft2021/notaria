import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import SideBar from "../components/sidebar/SideBar";
import TopBar from "../components/topbar/TopBar";
import Table from "../components/table/Table";
import Input from "../components/input/Input";
import TitleHeader from "../components/title/TitleHeader";
import styles from "../scss/pages/CatalogoActos.module.scss";
import Button from "../components/button/Button";

export default function CatalogoActos() {
  const [openBar, setOpenBar] = useState("");
  let navigate = useNavigate();

  const handleClick = () => {
    navigate("/configuracion");
  };

  const handleGetStateBar = (openBar) => {
    setOpenBar(openBar);
  };
  return (
    <div className={styles.tramiteContainer}>
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
            <TitleHeader text="Catálogo de Usuarios" withoutIcon />
          </div>
          <div className={styles.formSearchContainer}>
            <form>
              <div className={styles.inputContainer}>
                <Input placeholder="Buscar" type="text" variant="searchUser" />
              </div>
              <div className={styles.buttonContainer}>
                <Button
                  text="+ Agregar nuevo usuario"
                  variant="addUserButton"
                  onClick={handleClick}
                />
              </div>
            </form>
          </div>
          <div className={styles.tableContentContainer}>
            <Table />
          </div>
        </div>
      </div>
    </div>
  );
}
