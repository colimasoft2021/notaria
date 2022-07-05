import React from "react";
import Button from "../button/Button";
import arrowBlueIcon from "../../icons/arrowBlueIcon.png";
import styles from "./TitleHeader.module.scss";

export default function TitleHeader({ text, icon, banner, withoutIcon }) {
    return (
        <div className={styles.titleHeaderContainer}>
            {banner ? (
                <>
                    <div className={styles.bannerContainer}>
                        <div className={styles.banner}>
                            <div className={styles.containerBlue}>
                                <h1>{text}</h1>
                            </div>
                            <div className={styles.containerWhite}>
                                <Button icon={icon} download variantIcon="download" />
                            </div>
                        </div>
                    </div>
                </>
            ) : (
                <>
                    <div className={styles.iconTextContainer}>
                        <div
                            className={
                                withoutIcon
                                    ? `${styles.iconContainer} ${styles.withoutIcon}`
                                    : styles.iconContainer
                            }
                        >
                            <img
                                className={styles.icon}
                                src={arrowBlueIcon}
                                alt={`Icono de Flecha`}
                            />
                        </div>
                        <div className={styles.titleContainer}>
                            <h1>{text}</h1>
                        </div>
                    </div>
                </>
            )}
            {icon && !banner ? (
                <div className={styles.downloadContainer}>
                    <Button
                        icon={icon}
                        text="Descargar Excel"
                        download
                        variantIcon="download"
                    />
                </div>
            ) : (
                <></>
            )}
        </div>
    );
}
