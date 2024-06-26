import {useNavigate} from "react-router-dom";

function SidebarLogo() {
    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    return (
        <div  className="sidebar-logo">
            <a href={''} onClick={() => handleClick('/')}>Budżet Plan</a>
        </div>
    );
}

export default SidebarLogo;