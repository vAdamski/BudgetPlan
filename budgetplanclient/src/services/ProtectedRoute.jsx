import { useEffect, useState } from 'react';
import userManager from "./authConfig.jsx";

const ProtectedRoute = ({ allowedRoles = [], children, unauthorizedContent = null }) => {
    const [isLoading, setIsLoading] = useState(true);
    const [hasAccess, setHasAccess] = useState(false);

    const noAccessContent = unauthorizedContent || (
        <div className="container-fluid d-flex justify-content-center align-items-center" style={{ height: '80vh' }}>
            <div className="row">
                <div className="col-12 text-center">
                    <h1>Brak dostÄpu</h1>
                </div>
            </div>
        </div>
    );

    useEffect(() => {
        const checkUser = async () => {
            const loadedUser = await userManager.getUser();
            if (!loadedUser) {
                userManager.signinRedirect();
            } else {
                const userRoles = loadedUser.profile?.role || [];
                const accessGranted = allowedRoles.length === 0 || allowedRoles.some(role => userRoles.includes(role));
                setHasAccess(accessGranted);
                setIsLoading(false);
            }
        };

        checkUser();
    }, [allowedRoles]);

    if (isLoading) {
        return (
            <div className="container-fluid d-flex justify-content-center align-items-center" style={{ height: '80vh' }}>
                <div className="row">
                    <div className="col-12 text-center">
                        <h1>Ĺadowanie strony ...</h1>
                        <div className="spinner-border" role="status"></div>
                    </div>
                </div>
            </div>
        );
    }

    if (!hasAccess) {
        return noAccessContent;
    }

    return children;
};

export default ProtectedRoute;