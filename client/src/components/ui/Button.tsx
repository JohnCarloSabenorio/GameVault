type buttonProps = {
  label: string;
  variant?: string;
};

export default function Button({ label, variant }: buttonProps) {
  return (
    <>
      <button className={`btn ${variant}`}>{label}</button>
    </>
  );
}
