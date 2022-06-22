import React, { useState } from "react";
import Button from "../button/Button";
import userIcon from "../../icons/userIcon.png";
import clarityNotificationSolidIcon from "../../icons/clarityNotificationSolidIcon.png";
import clarityNotificationIcon from "../../icons/clarityNotificationIcon.png";
import styles from "./TopBar.module.scss";

export default function TopBar() {
    const [notification, setNotification] = useState(false);

    const handleNotificationOn = () => {
        setNotification(true);
    };

    const handleNotificationOff = () => {
        setNotification(false);
    };

    return (
        <div className={styles.topBarContainer}>
            <div className={styles.optionsContainer}>
                <div className={styles.optionContainer}>
                    <div className={styles.iconContainer}>
                        {!notification ? (
                            <Button
                                icon={clarityNotificationSolidIcon}
                                variantIcon="topBarIcon"
                                onClick={handleNotificationOn}
                            />
                        ) : (
                            <Button
                                icon={clarityNotificationIcon}
                                variantIcon="topBarIcon"
                                onClick={handleNotificationOff}
                            />
                        )}
                    </div>
                </div>
                <div className={styles.optionContainer}>
                    <Button
                        icon={userIcon}
                        variantIcon="topBarIcon"
                        text="Administrador"
                        openBar={true}
                    />
                </div>
            </div>
        </div>
    );
}
