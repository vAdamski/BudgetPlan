function SidebarDropdown({id, target, icon, label, children}) {
    return (
        <li className="sidebar-item">
            <a href="#" className="sidebar-link collapsed has-dropdown d-flex align-content-center" data-bs-toggle="collapse"
               data-bs-target={`#${target}`} aria-expanded="false" aria-controls={target}>
                <span className={`material-icons-outlined`}>{icon}</span>
                <span className={'mx-2'}>{label}</span>
            </a>
            <ul id={id} className="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                {children}
            </ul>
        </li>
    );
}

export default SidebarDropdown;