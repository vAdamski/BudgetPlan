import {useContext} from "react";
import {AuthContext} from "../../services/authProvider.jsx";

function SidebarFooter() {
    const {user, login, logout} = useContext(AuthContext);

    const userName = user && user.profile ? user.profile.name : '';


    return (
        <>
            {user ?
                (
                    <div className="sidebar-footer">
                        <a className="sidebar-link d-flex align-content-center">
                            <span className="material-icons-outlined">person</span>
                            <span className={'mx-2'}>Witaj {userName}!</span>
                        </a>
                        <a className="sidebar-link d-flex align-content-center" onClick={logout}>
                            <span className="material-icons-outlined">logout</span>
                            <span className={'mx-2'}>Wyloguj się</span>
                        </a>
                    </div>
                )
                :
                (
                    <div className="sidebar-footer">
                        <a className="sidebar-link" onClick={login}>
                            <i className="lni lni-enter"></i>
                            <span>Zaloguj się</span>
                        </a>
                    </div>
                )
            }
        </>

    );
}

export default SidebarFooter;