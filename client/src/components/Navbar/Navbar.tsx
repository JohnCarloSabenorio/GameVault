import Button from "../ui/Button";
import Link from "../ui/Link";

export default function Navbar() {
  return (
    <>
      <div className="bg-blue-200 w-full flex items-center justify-between p-3">
        {/* Logo and Website Name */}
        <div className="flex items-center gap-3">
          <img
            className="w-10 h-10"
            src="images/gamevault-logo.png"
            alt="GameVault Logo"
          ></img>
          <h1 className="text-3xl font-bold">GameVault</h1>
        </div>

        <div className="flex items-center gap-3">
          {/* Search Bar */}
          <input
            type="text"
            className="w-lg text-input"
            placeholder="Search here..."
          />
          {/* Navigation Links */}
          <div className="flex gap-3">
            <Link linkUrl="" label="Home" />
            <Link linkUrl="" label="Games" />
            <Link linkUrl="" label="Consoles" />
            <Link linkUrl="" label="Developers" />
            <Link linkUrl="" label="Publishers" />
            <Link linkUrl="" label="Collections" />
            <Link linkUrl="" label="Help" />
          </div>

          {/* Authentication Buttons */}
          <div className="flex gap-3">
            <Button label={"Login"} variant="btn-login" />
            <Button label={"Register"} variant="btn-register" />
          </div>
        </div>
      </div>
    </>
  );
}
