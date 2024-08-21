import { useEffect, useState } from "react";
import userManager from "./authConfig.jsx";

const AuthorizedView = ({ allowedRoles = [], children, unauthorizedContent = null }) => {
    const [hasAccess, setHasAccess] = useState(false);

    useEffect(() => {
        const checkUser = async () => {
            const loadedUser = await userManager.getUser();
            if (loadedUser) {
                const userRoles = loadedUser.profile?.role || [];
                const accessGranted = allowedRoles.length === 0 || allowedRoles.some(role => userRoles.includes(role));
                setHasAccess(accessGranted);
            }
        };

        checkUser();
    }, [allowedRoles]);

    if (!hasAccess) {
        return unauthorizedContent || null;
    }

    return children;
};

export default AuthorizedView;