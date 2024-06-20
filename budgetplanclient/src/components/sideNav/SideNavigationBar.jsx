import './SideNavigationBar.css';
import {useNavigate} from "react-router-dom";
import {useContext} from 'react';
import {AuthContext} from '../../services/authProvider.jsx';
import UserProfileInfoListItem from "./UserProfileInfoListItem.jsx";

function SideNavigationBar() {
    const {user, login, logout} = useContext(AuthContext);
    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    return (
        <>
            <div className={'top-nav-bar'}>
                <div className={'app-brand'}>
                    <a>Twój budżet</a>
                </div>
                <div className={'nav-bar-toggle'}>
                    <span className="material-symbols-outlined">chevron_left</span>
                </div>
            </div>
            <div>
                <nav>
                    {
                        user ? (
                            <>
                                <div className={'navbar-item'} onClick={() => handleClick('/')}>
                                    <span className="material-symbols-outlined">home</span>
                                    <a>Pulpit</a>
                                </div>
                                <div className={'navbar-item'} onClick={() => handleClick('/TransactionCategory')}>
                                    <span className="material-symbols-outlined">category</span>
                                    <a>Kategorie</a>
                                </div>
                                <div className={'navbar-item'} onClick={logout}>
                                    <span className="material-symbols-outlined">logout</span>
                                    <a>Wyloguj</a>
                                </div>
                                <UserProfileInfoListItem/>
                            </>
                        ) : (
                            <>
                                <div className={'navbar-item'} onClick={login}>
                                    <span className="material-symbols-outlined">login</span>
                                    <a>Zaloguj</a>
                                </div>
                            </>
                        )
                    }
                </nav>
            </div>
        </>
    );
}

export default SideNavigationBar;