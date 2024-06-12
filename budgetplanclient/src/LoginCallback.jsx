import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import userManager from './AuthConfig';

const LoginCallback = () => {
    const navigate = useNavigate();

    useEffect(() => {
        userManager.signinRedirectCallback().then(() => {
            console.log('Login callback successful');
            navigate('/');
        }).catch((err) => {
            console.error('Error in login callback:', err);
        });
    }, [navigate]);

    return <div>Logging in...</div>;
};

export default LoginCallback;