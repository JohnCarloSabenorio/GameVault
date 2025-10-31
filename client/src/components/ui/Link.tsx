export default function Link({
  linkUrl,
  label,
}: {
  linkUrl: string;
  label: string;
}) {
  return (
    <>
      <a href={linkUrl}>{label}</a>
    </>
  );
}
