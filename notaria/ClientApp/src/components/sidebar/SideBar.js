import React, { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import styles from "./SideBar.module.scss";
import Button from "../button/Button";
import Logo from "../../images/logo.png";
import houseIcon from "../../icons/houseIcon.png";
import fileIconBlue from "../../icons/fileIconBlue.png";
import searchIcon from "../../icons/searchIcon.png";
import listIcon from "../../icons/listIcon.png";
import archiveFileIcon from "../../icons/archivesFileIcon.png";
import nutIcon from "../../icons/nutIcon.png";
import userIconSquare from "../../icons/userIconSquare.png";
import arrowBlue from "../../icons/arrowBlueIcon.png";

export default function SideBar({ handleStateBar }) {
    const [openBar, setOpenBar] = useState(true);

    const handleOpenBar = () => {
        setOpenBar(false);
        handleStateBar(openBar);
    };

    const handleCloseBar = () => {
        setOpenBar(true);
        handleStateBar(openBar);
    };

    const url = useLocation();

    return (
        <div
            className={
                openBar
                    ? styles.sideBarContainer
                    : `${styles.sideBarContainer} ${styles.sideBarClose}`
            }
        >
            <div className={styles.contentContainer}>
                <div
                    className={
                        openBar
                            ? styles.imageContainer
                            : `${styles.imageContainer} ${styles.imageContainerClose}`
                    }
                >
                    {openBar ? (
                        <div className={styles.iconContainer}>
                            <Button icon={arrowBlue} onClick={handleOpenBar} />
                        </div>
                    ) : (
                        <></>
                    )}
                    <div className={styles.logoContainer}>
                        <img
                            className={openBar ? styles.logo : styles.smallLogo}
                            src={Logo}
                            alt="Logo"
                        />
                    </div>
                    {!openBar ? (
                        <div className={styles.iconContainerClose}>
                            <Button
                                icon={arrowBlue}
                                onClick={handleCloseBar}
                                variantIcon="openSideBar"
                                variant="openSideBarButton"
                            />
                        </div>
                    ) : (
                        <></>
                    )}
                </div>
                <div className={styles.menuContainer}>
                    <div className={styles.optionsMenu}>
                        <div
                            className={
                                openBar && url.pathname === "/inicio"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/inicio"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/inicio"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/inicio">
                                <Button icon={houseIcon} text="Inicio" openBar={openBar} />
                            </Link>
                        </div>
                        <div
                            className={
                                openBar && url.pathname === "/tramite"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/tramite"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/tramite"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/tramite">
                                <Button
                                    icon={fileIconBlue}
                                    text="Iniciar nuevo trámites"
                                    openBar={openBar}
                                />
                            </Link>
                        </div>
                        <div
                            className={
                                openBar && url.pathname === "/seguimiento-tramites"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/seguimiento-tramites"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/seguimiento-tramites"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/seguimiento-tramites">
                                <Button
                                    icon={searchIcon}
                                    text="Seguimiento Trámites"
                                    openBar={openBar}
                                />
                            </Link>
                        </div>
                        <div
                            className={
                                openBar && url.pathname === "/catalogo-responsable"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/catalogo-responsable"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/catalogo-responsable"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/catalogo-responsable">
                                <Button icon={listIcon} text="Catálogos" openBar={openBar} />
                            </Link>
                        </div>
                        <div
                            className={
                                openBar && url.pathname === "/catalogo-actos"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/catalogo-actos"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/catalogo-actos"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/catalogo-actos">
                                <Button
                                    icon={archiveFileIcon}
                                    text="Catálogo de actos"
                                    openBar={openBar}
                                />
                            </Link>
                        </div>
                        <div
                            className={
                                openBar && url.pathname === "/configuracion"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/configuracion"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/configuracion"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/configuracion">
                                <Button icon={nutIcon} text="Configuración" openBar={openBar} />
                            </Link>
                        </div>
                        <div
                            className={
                                openBar && url.pathname === "/"
                                    ? `${styles.optionContainer} ${styles.optionActive}`
                                    : openBar && url.pathname !== "/"
                                        ? styles.optionContainer
                                        : !openBar && url.pathname === "/"
                                            ? `${styles.withoutText} ${styles.optionActive}`
                                            : styles.withoutText
                            }
                        >
                            <Link to="/">
                                <Button
                                    icon={userIconSquare}
                                    text="Usuarios"
                                    openBar={openBar}
                                />
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
